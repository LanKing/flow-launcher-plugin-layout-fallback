namespace Flow.Launcher.Plugin.LayoutFallback;

internal sealed record KeyboardLayoutInfo(
    IntPtr Handle,
    int LanguageId,
    string CultureName,
    string DisplayName,
    string Source,
    bool IsLatinBased);

internal sealed record LayoutMap(
    KeyboardLayoutInfo From,
    KeyboardLayoutInfo To,
    IReadOnlyDictionary<char, char> Characters);

internal enum LayoutFallbackKind
{
    Strong,
    WeakLatin
}

internal sealed record LayoutCorrection(
    string Text,
    KeyboardLayoutInfo From,
    KeyboardLayoutInfo To,
    LayoutFallbackKind Kind,
    int ExtraScorePenalty);
