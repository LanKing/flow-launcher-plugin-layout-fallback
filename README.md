**Adds lower-priority fallback results by converting the query between keyboard layouts available on the user's Windows system.**

![Plugin function demo](/doc/demo.png)

> When I installed Flow Launcher, I was genuinely surprised that I could not find a plugin like this. It made me wonder how much human time has been wasted retyping, deleting, and correcting text entered in the wrong keyboard layout.

Samples:
* `Yfcnhjqrb` -> additionally searches `Настройки`
* `руддщ` -> additionally searches `hello`

The original Flow Launcher results stay untouched and remain higher. Fallback results are marked with `⌨` and receive a strong score penalty.

## How it works

1. Reads installed Windows keyboard layouts with `GetKeyboardLayoutList`, `HKCU\Keyboard Layout\Preload`, and `HKCU\Keyboard Layout\Substitutes`.
2. Builds conversion maps between every ordered pair of available layouts.
3. Generates corrected query candidates and filters out weak or duplicate conversions.
4. Queries the other global Flow Launcher plugins with the corrected candidates.
5. Appends lower-priority fallback results without touching the original Flow Launcher results.

Explicit action-keyword queries are ignored, so the plugin only participates in ordinary global searches.

## Supported keyboard layouts

Layout Fallback works best with direct keyboard layouts where the same physical keys produce different characters.

Best candidates include 🇺🇸 English US, 🇬🇧 English UK, 🇷🇺 Russian, 🇺🇦 Ukrainian, 🇧🇾 Belarusian, 🇧🇬 Bulgarian, 🇷🇸 Serbian Cyrillic, 🇲🇰 Macedonian, 🇰🇿 Kazakh, 🇰🇬 Kyrgyz, 🇲🇳 Mongolian Cyrillic, 🇬🇷 Greek, 🇮🇱 Hebrew, 🇸🇦 Arabic, 🇮🇷 Persian, 🇦🇲 Armenian, 🇬🇪 Georgian, 🇹🇭 Thai, 🇵🇱 Polish 214, and 🇵🇱 Polish Typewriter.

Latin-based layouts may also work, but the benefit is usually smaller because many characters overlap with English. This includes 🇩🇪 German, 🇫🇷 French AZERTY, 🇪🇸 Spanish, 🇮🇹 Italian, 🇵🇹 Portuguese, 🇹🇷 Turkish Q, 🇨🇿 Czech QWERTY, 🇸🇰 Slovak QWERTY, 🇭🇺 Hungarian, 🇷🇴 Romanian, 🇱🇹 Lithuanian, 🇱🇻 Latvian, 🇪🇪 Estonian, 🇭🇷 Croatian, 🇸🇮 Slovenian, 🇦🇱 Albanian, 🇧🇦 Bosnian Latin, 🇷🇸 Serbian Latin, 🇳🇱 Dutch, 🇩🇰 Danish, 🇳🇴 Norwegian, 🇸🇪 Swedish, 🇫🇮 Finnish, and 🇮🇸 Icelandic.

Some layouts may have limited support because they rely on IME, dead keys, complex composition, AltGr-heavy input, or candidate selection. This includes 🇨🇳 Chinese Simplified IME, 🇹🇼 Chinese Traditional IME, 🇯🇵 Japanese IME, 🇰🇷 Korean IME, 🇻🇳 Vietnamese Telex, 🇻🇳 Vietnamese VNI, 🇮🇳 Hindi Devanagari input, 🇧🇩 Bengali input, 🇮🇳 Tamil input, 🇮🇳 Telugu input, 🇮🇳 Kannada input, 🇮🇳 Malayalam input, 🇹🇭 Thai Kedmanee variants with complex composition, 🇺🇸 US International, 🇬🇧 United Kingdom Extended, 🇨🇦 Canadian Multilingual Standard, 🇨🇦 French Canadian, 🇪🇸 Spanish International, 🇵🇹 Portuguese ABNT, 🇧🇷 Portuguese ABNT2, 🇨🇿 Czech Programmers, 🇸🇰 Slovak Programmers, 🇭🇺 Hungarian 101-key, and 🇵🇱 Polish Programmer.

Polish Programmer is technically compatible, but it provides limited fallback value because Polish-specific characters such as ą, ć, ę, ł, ń, ó, ś, ź, and ż are entered through AltGr. 🇵🇱 Polish 214 and 🇵🇱 Polish Typewriter are compatible and are better candidates for Layout Fallback.

## Notes

* Fallback output is limited to 20 results and 6 results per source plugin.
* Some third-party plugins may behave differently when queried indirectly, so fallback results can vary by source plugin.
* Layout Fallback does not translate or transliterate text. It only reinterprets the same physical key presses through other installed Windows keyboard layouts.

## Build

Requires .NET 9 SDK:

```powershell
winget install Microsoft.DotNet.SDK.9
```

Then run `build.cmd` or manually call `build.ps1`:

```powershell
Set-ExecutionPolicy -Scope Process Bypass
.\build.ps1
```

The installable ZIP will be created at:

```text
artifacts\LayoutFallback-0.1.3.zip
```

For local development installation:

```powershell
.\install-dev.ps1
```

Then restart Flow Launcher.
