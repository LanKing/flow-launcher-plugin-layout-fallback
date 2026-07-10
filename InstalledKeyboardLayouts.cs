using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace Flow.Launcher.Plugin.LayoutFallback;

internal static class InstalledKeyboardLayouts
{
    [DllImport("user32.dll")]
    private static extern int GetKeyboardLayoutList(int nBuff, [Out] IntPtr[]? lpList);

    public static IReadOnlyList<KeyboardLayoutInfo> GetInstalledLayouts()
    {
        var handles = new List<(IntPtr Handle, string Source)>();
        var seen = new HashSet<long>();

        AddFromWinApi(handles, seen);
        AddFromRegistry(handles, seen);

        return handles
            .Select(item => ToInfo(item.Handle, item.Source))
            .Where(info => info.LanguageId > 0)
            .ToArray();
    }

    private static void AddFromWinApi(List<(IntPtr Handle, string Source)> handles, HashSet<long> seen)
    {
        var count = GetKeyboardLayoutList(0, null);
        if (count <= 0)
            return;

        var layouts = new IntPtr[count];
        var actualCount = GetKeyboardLayoutList(layouts.Length, layouts);

        foreach (var layout in layouts.Take(actualCount))
            AddHandle(handles, seen, layout, "winapi");
    }

    private static void AddFromRegistry(List<(IntPtr Handle, string Source)> handles, HashSet<long> seen)
    {
        using var preload = Registry.CurrentUser.OpenSubKey(@"Keyboard Layout\Preload");
        if (preload is null)
            return;

        var substitutes = ReadSubstitutes();

        foreach (var name in preload.GetValueNames())
        {
            if (preload.GetValue(name) is not string raw || string.IsNullOrWhiteSpace(raw))
                continue;

            if (substitutes.TryGetValue(raw, out var substitute))
                raw = substitute;

            if (!long.TryParse(raw, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var value))
                continue;

            AddHandle(handles, seen, new IntPtr(value), "registry");
        }
    }

    private static Dictionary<string, string> ReadSubstitutes()
    {
        var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        using var substitutes = Registry.CurrentUser.OpenSubKey(@"Keyboard Layout\Substitutes");
        if (substitutes is null)
            return result;

        foreach (var name in substitutes.GetValueNames())
        {
            if (substitutes.GetValue(name) is string value && !string.IsNullOrWhiteSpace(value))
                result[name] = value;
        }

        return result;
    }

    private static void AddHandle(
        List<(IntPtr Handle, string Source)> handles,
        HashSet<long> seen,
        IntPtr handle,
        string source)
    {
        if (handle == IntPtr.Zero)
            return;

        var value = handle.ToInt64();
        if (seen.Add(value))
            handles.Add((handle, source));
    }

    private static KeyboardLayoutInfo ToInfo(IntPtr handle, string source)
    {
        var languageId = (int)(handle.ToInt64() & 0xffff);
        var isLatinBased = KeyboardLayoutClassifier.IsLatinBased(handle);

        try
        {
            var culture = CultureInfo.GetCultureInfo(languageId);
            return new KeyboardLayoutInfo(
                handle,
                languageId,
                culture.Name,
                culture.DisplayName,
                source,
                isLatinBased);
        }
        catch (CultureNotFoundException)
        {
            return new KeyboardLayoutInfo(
                handle,
                languageId,
                $"0x{languageId:X4}",
                $"0x{languageId:X4}",
                source,
                isLatinBased);
        }
    }
}
