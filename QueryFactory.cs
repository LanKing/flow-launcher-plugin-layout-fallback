using System.Reflection;
using Flow.Launcher.Plugin;

namespace Flow.Launcher.Plugin.LayoutFallback;

internal static class QueryFactory
{
    private const BindingFlags PropertyFlags =
        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

    public static Query Create(Query source, string correctedSearch)
    {
        var query = new Query();
        var searchTerms = correctedSearch.Split(
            Query.TermSeparator,
            StringSplitOptions.RemoveEmptyEntries);

        // Flow 1.x used RawQuery. Flow 2.x additionally uses OriginalQuery and TrimmedQuery.
        // Reflection keeps one plugin binary compatible with both models.
        TrySet(query, "OriginalQuery", correctedSearch);
        TrySet(query, "RawQuery", correctedSearch);
        TrySet(query, "TrimmedQuery", correctedSearch);
        TrySet(query, "Search", correctedSearch);
        TrySet(query, "SearchTerms", searchTerms);
        TrySet(query, "ActionKeyword", string.Empty);
        TrySet(query, "IsReQuery", source.IsReQuery);
        TrySet(query, "IsHomeQuery", false);

        return query;
    }

    public static void TrySet(object target, string propertyName, object? value)
    {
        var property = target.GetType().GetProperty(propertyName, PropertyFlags);
        var setter = property?.GetSetMethod(nonPublic: true);

        if (setter is not null)
            setter.Invoke(target, new[] { value });
    }

    public static object? TryGet(object target, string propertyName)
    {
        var property = target.GetType().GetProperty(propertyName, PropertyFlags);
        return property?.GetValue(target);
    }
}
