namespace Flow.Launcher.Plugin.LayoutFallback;

internal static class KeyboardLayoutClassifier
{
    private const double LatinRatioThreshold = 0.70;

    public static bool IsLatinBased(IntPtr layoutHandle)
    {
        var letters = 0;
        var latinLetters = 0;

        for (var virtualKey = 0x41; virtualKey <= 0x5A; virtualKey++)
        {
            CountCharacter(layoutHandle, virtualKey, shift: false, ref letters, ref latinLetters);
            CountCharacter(layoutHandle, virtualKey, shift: true, ref letters, ref latinLetters);
        }

        if (letters == 0)
            return false;

        return latinLetters >= Math.Ceiling(letters * LatinRatioThreshold);
    }

    private static void CountCharacter(
        IntPtr layoutHandle,
        int virtualKey,
        bool shift,
        ref int letters,
        ref int latinLetters)
    {
        var character = KeyboardLayoutNative.TryGetCharacter(layoutHandle, virtualKey, shift);
        if (character is null || !char.IsLetter(character.Value))
            return;

        letters++;

        if (IsLatinLetter(character.Value))
            latinLetters++;
    }

    private static bool IsLatinLetter(char character) =>
        character is >= 'A' and <= 'Z'
        || character is >= 'a' and <= 'z'
        || character is >= '\u00C0' and <= '\u024F'
        || character is >= '\u1E00' and <= '\u1EFF';
}
