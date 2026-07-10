using System.IO;
using Flow.Launcher.Plugin;

namespace Flow.Launcher.Plugin.LayoutFallback;

public sealed class Main : IAsyncPlugin
{
    private const string DefaultPluginId = "D1A7E9C48B6F4A5A8F963DA278F41921";
    private const int MaxResults = 20;
    private const int MaxResultsPerPlugin = 6;
    private const int ScorePenalty = 10_000;

    private IPublicAPI? _api;
    private string _pluginId = DefaultPluginId;
    private IReadOnlyList<KeyboardLayoutInfo> _layouts = Array.Empty<KeyboardLayoutInfo>();
    private IReadOnlyList<LayoutMap> _maps = Array.Empty<LayoutMap>();

    public Task InitAsync(PluginInitContext context)
    {
        _api = context.API;
        _pluginId = context.CurrentPluginMetadata?.ID ?? DefaultPluginId;
        _layouts = InstalledKeyboardLayouts.GetInstalledLayouts();
        _maps = LayoutConverter.BuildMaps(_layouts);

        _api?.LogInfo(
            nameof(Main),
            $"Loaded {_layouts.Count} keyboard layout(s), built {_maps.Count} conversion map(s).");

        return Task.CompletedTask;
    }

    public async Task<List<Result>> QueryAsync(Query query, CancellationToken token)
    {
        if (_api is null || query is null || _maps.Count == 0)
            return new List<Result>();

        // A wildcard plugin participates only in ordinary global searches.
        // Do not interfere with explicit action-keyword queries.
        if (!string.IsNullOrEmpty(query.ActionKeyword) || string.IsNullOrWhiteSpace(query.Search))
            return new List<Result>();

        var corrections = LayoutConverter.CorrectAll(query.Search, _maps);
        if (corrections.Count == 0)
            return new List<Result>();

        var plugins = _api.GetAllPlugins()
            .Where(IsEligibleGlobalPlugin)
            .ToArray();

        var tasks = corrections
            .SelectMany(correction =>
            {
                var correctedQuery = QueryFactory.Create(query, correction.Text);
                return plugins.Select(plugin => QueryPluginSafelyAsync(plugin, correctedQuery, correction, token));
            });

        var batches = await Task.WhenAll(tasks).ConfigureAwait(false);
        token.ThrowIfCancellationRequested();

        var prepared = batches
            .SelectMany(batch => batch)
            .Where(item => item.Result is not null && !string.IsNullOrWhiteSpace(item.Result.Title))
            .OrderByDescending(item => item.Score)
            .GroupBy(item => BuildDuplicateKey(item.Source, item.Result), StringComparer.OrdinalIgnoreCase)
            .Select(group => group.First())
            .Take(MaxResults)
            .Select(item => PrepareResult(item.Source, item.Result, item.Correction, item.Score))
            .ToList();

        return prepared;
    }

    private bool IsEligibleGlobalPlugin(PluginPair pair)
    {
        if (pair?.Plugin is null || pair.Metadata is null || pair.Metadata.Disabled)
            return false;

        if (string.Equals(pair.Metadata.ID, _pluginId, StringComparison.OrdinalIgnoreCase))
            return false;

        return pair.Metadata.ActionKeywords?.Contains(Query.GlobalPluginWildcardSign) == true
               || string.Equals(
                   pair.Metadata.ActionKeyword,
                   Query.GlobalPluginWildcardSign,
                   StringComparison.Ordinal);
    }

    private async Task<List<SourceResult>> QueryPluginSafelyAsync(
        PluginPair source,
        Query correctedQuery,
        LayoutCorrection correction,
        CancellationToken token)
    {
        try
        {
            var results = await source.Plugin.QueryAsync(correctedQuery, token).ConfigureAwait(false);
            token.ThrowIfCancellationRequested();

            return (results ?? new List<Result>())
                .Where(result => result is not null)
                .OrderByDescending(result => result.Score)
                .Take(MaxResultsPerPlugin)
                .Select(result => new SourceResult(
                    source,
                    result,
                    correction,
                    CalculateFallbackScore(result, correction)))
                .ToList();
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            _api?.LogDebug(
                nameof(Main),
                $"Fallback query failed for plugin '{source.Metadata.Name}': {exception.Message}");

            return new List<SourceResult>();
        }
    }

    private static Result PrepareResult(
        PluginPair source,
        Result sourceResult,
        LayoutCorrection correction,
        int fallbackScore)
    {
        var result = sourceResult.Clone();
        var originalSubtitle = result.SubTitle;
        var originalCopyText = result.CopyText;

        MakeIconAbsolute(result, source.Metadata.PluginDirectory);
        MakeOptionalBadgeAbsolute(result, source.Metadata.PluginDirectory);

        result.SubTitle = string.IsNullOrWhiteSpace(originalSubtitle)
            ? $"⌨ {correction.Text} · {source.Metadata.Name}"
            : $"⌨ {correction.Text} · {source.Metadata.Name} · {originalSubtitle}";

        result.CopyText = originalCopyText;
        result.Score = fallbackScore;

        // These properties exist in newer Flow versions. Reflection preserves compatibility
        // with the currently published 4.4.0 plugin SDK.
        QueryFactory.TrySet(result, "AddSelectedCount", false);
        QueryFactory.TrySet(result, "QuerySuggestionText", null);
        QueryFactory.TrySet(
            result,
            "RecordKey",
            $"layout-fallback:{source.Metadata.ID}:{correction.Text}:{result.Title}");

        return result;
    }

    private static void MakeIconAbsolute(Result result, string? pluginDirectory)
    {
        if (string.IsNullOrWhiteSpace(result.IcoPath)
            || string.IsNullOrWhiteSpace(pluginDirectory)
            || IsAbsoluteOrRemote(result.IcoPath))
        {
            return;
        }

        result.IcoPath = Path.GetFullPath(Path.Combine(pluginDirectory, result.IcoPath));
    }

    private static void MakeOptionalBadgeAbsolute(Result result, string? pluginDirectory)
    {
        if (string.IsNullOrWhiteSpace(pluginDirectory))
            return;

        var badge = QueryFactory.TryGet(result, "BadgeIcoPath") as string;
        if (string.IsNullOrWhiteSpace(badge) || IsAbsoluteOrRemote(badge))
            return;

        QueryFactory.TrySet(
            result,
            "BadgeIcoPath",
            Path.GetFullPath(Path.Combine(pluginDirectory, badge)));
    }

    private static bool IsAbsoluteOrRemote(string path) =>
        Path.IsPathRooted(path)
        || path.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
        || path.StartsWith("https://", StringComparison.OrdinalIgnoreCase)
        || path.StartsWith("data:image", StringComparison.OrdinalIgnoreCase);

    private static int CalculateFallbackScore(Result result, LayoutCorrection correction)
    {
        var penalty = ScorePenalty + correction.ExtraScorePenalty;
        return Math.Max(-30_000, Math.Min(result.Score, 1_000) - penalty);
    }

    private static string BuildDuplicateKey(PluginPair source, Result result) =>
        $"{source.Metadata.ID}{result.Title}{result.SubTitle}";

    private sealed record SourceResult(
        PluginPair Source,
        Result Result,
        LayoutCorrection Correction,
        int Score);
}
