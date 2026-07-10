using System.Runtime.InteropServices;
using System.Text;

namespace Flow.Launcher.Plugin.LayoutFallback;

internal static class KeyboardLayoutNative
{
    private const int VkShift = 0x10;
    private const uint MapVkVkToVsc = 0;
    private const uint ToUnicodeNoStateChange = 0x4;

    [DllImport("user32.dll")]
    private static extern uint MapVirtualKeyEx(uint uCode, uint uMapType, IntPtr dwhkl);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int ToUnicodeEx(
        uint wVirtKey,
        uint wScanCode,
        byte[] lpKeyState,
        [Out] StringBuilder pwszBuff,
        int cchBuff,
        uint wFlags,
        IntPtr dwhkl);

    public static char? TryGetCharacter(IntPtr layoutHandle, int virtualKey, bool shift)
    {
        var keyState = new byte[256];
        if (shift)
            keyState[VkShift] = 0x80;

        var scanCode = MapVirtualKeyEx((uint)virtualKey, MapVkVkToVsc, layoutHandle);
        if (scanCode == 0)
            return null;

        var buffer = new StringBuilder(8);
        var result = ToUnicodeEx(
            (uint)virtualKey,
            scanCode,
            keyState,
            buffer,
            buffer.Capacity,
            ToUnicodeNoStateChange,
            layoutHandle);

        if (result <= 0 || buffer.Length == 0)
            return null;

        return buffer[0];
    }
}
