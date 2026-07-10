using System.Text;

namespace Flow.Launcher.Plugin.LayoutFallback;

internal static class LayoutConverter
{
    private const int StrongMinChangedCharacters = 2;
    private const double StrongMinChangedLetterRatio = 0.50;

    private const int WeakLatinMinChangedCharacters = 1;
    private const double WeakLatinMinChangedLetterRatio = 0.10;
    private const int WeakLatinExtraScorePenalty = 10_000;

    public static IReadOnlyList<LayoutMap> BuildMaps(IReadOnlyList<KeyboardLayoutInfo> layouts)
    {
        if (layouts.Count < 2)
            return Array.Empty<LayoutMap>();

        var maps = new List<LayoutMap>();

        foreach (var from in layouts)
        {
            foreach (var to in layouts)
            {
                if (from.Handle == to.Handle)
                    continue;

                var characters = BuildCharacterMap(from.Handle, to.Handle);
                if (characters.Count >= 8)
                    maps.Add(new LayoutMap(from, to, characters));
            }
        }

        return maps;
    }

    public static IReadOnlyList<LayoutCorrection> CorrectAll(
        string input,
        IReadOnlyList<LayoutMap> maps)
    {
        if (string.IsNullOrWhiteSpace(input) || maps.Count == 0)
            return Array.Empty<LayoutCorrection>();

        var letters = input.Count(char.IsLetter);
        if (letters == 0)
            return Array.Empty<LayoutCorrection>();

        var result = new List<LayoutCorrection>();
        var seen = new HashSet<string>(StringComparer.Ordinal);

        foreach (var map in maps)
        {
            var profile = GetFilterProfile(map);

            var corrected = CorrectWithMap(
                input,
                map.Characters,
                letters,
                profile.MinChangedCharacters,
                profile.MinChangedLetterRatio);

            if (corrected is null)
                continue;

            if (seen.Add(corrected))
            {
                result.Add(new LayoutCorrection(
                    corrected,
                    map.From,
                    map.To,
                    profile.Kind,
                    profile.ExtraScorePenalty));
            }
        }

        return result;
    }

    private static FilterProfile GetFilterProfile(LayoutMap map)
    {
        if (map.From.IsLatinBased && map.To.IsLatinBased)
        {
            return new FilterProfile(
                LayoutFallbackKind.WeakLatin,
                WeakLatinMinChangedCharacters,
                WeakLatinMinChangedLetterRatio,
                WeakLatinExtraScorePenalty);
        }

        return new FilterProfile(
            LayoutFallbackKind.Strong,
            StrongMinChangedCharacters,
            StrongMinChangedLetterRatio,
            0);
    }

    private static IReadOnlyDictionary<char, char> BuildCharacterMap(IntPtr fromLayout, IntPtr toLayout)
    {
        var map = new Dictionary<char, char>();

        for (var virtualKey = 0x08; virtualKey <= 0xFE; virtualKey++)
        {
            AddMappedCharacter(map, fromLayout, toLayout, virtualKey, shift: false);
            AddMappedCharacter(map, fromLayout, toLayout, virtualKey, shift: true);
        }

        return map;
    }

    private static void AddMappedCharacter(
        Dictionary<char, char> map,
        IntPtr fromLayout,
        IntPtr toLayout,
        int virtualKey,
        bool shift)
    {
        var from = KeyboardLayoutNative.TryGetCharacter(fromLayout, virtualKey, shift);
        var to = KeyboardLayoutNative.TryGetCharacter(toLayout, virtualKey, shift);

        if (from is null || to is null || from == to)
            return;

        map[from.Value] = to.Value;
    }

    private static string? CorrectWithMap(
        string input,
        IReadOnlyDictionary<char, char> map,
        int letters,
        int minChangedCharacters,
        double minChangedLetterRatio)
    {
        var builder = new StringBuilder(input.Length);
        var changed = 0;
        var changedLetters = 0;

        foreach (var character in input)
        {
            if (map.TryGetValue(character, out var replacement))
            {
                builder.Append(replacement);
                changed++;

                if (char.IsLetter(character) || char.IsLetter(replacement))
                    changedLetters++;
            }
            else
            {
                builder.Append(character);
            }
        }

        var corrected = builder.ToString();
        if (changed < minChangedCharacters)
            return null;

        if (changedLetters < Math.Ceiling(letters * minChangedLetterRatio))
            return null;

        if (string.Equals(input, corrected, StringComparison.Ordinal))
            return null;

        return corrected;
    }

    private sealed record FilterProfile(
        LayoutFallbackKind Kind,
        int MinChangedCharacters,
        double MinChangedLetterRatio,
        int ExtraScorePenalty);
}