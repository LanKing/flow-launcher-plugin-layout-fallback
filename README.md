🇺🇦 [Українська](doc/ua.md) | <sub>ru</sub> [Русский](doc/ru.md) | 🇧🇾 [Беларуская](doc/by.md) | 🇧🇬 [Български](doc/bg.md) | 🇷🇸 [Српски](doc/rs.md) | 🇲🇰 [Македонски](doc/mk.md) | 🇰🇿 [Қазақша](doc/kz.md) | 🇰🇬 [Кыргызча](doc/kg.md) | 🇲🇳 [Монгол](doc/mn.md) | 🇬🇷 [Ελληνικά](doc/gr.md) | 🇮🇱 [עברית](doc/il.md) | 🇸🇦 [العربية](doc/sa.md) | 🇮🇷 [فارسی](doc/ir.md) | 🇦🇲 [Հայերեն](doc/am.md) | 🇬🇪 [ქართული](doc/ge.md) | 🇹🇭 [ไทย](doc/th.md)

[![Flow Launcher](https://img.shields.io/badge/Flow%20Launcher-plugin-5c2d91?logo=windows&logoColor=white)](https://www.flowlauncher.com/)
[![Windows](https://img.shields.io/badge/Windows-10%2F11-0078D6?logo=windows&logoColor=white)](https://www.microsoft.com/windows)
[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Latest release](https://img.shields.io/github/v/release/LanKing/flow-launcher-plugin-layout-fallback?label=release)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![Downloads](https://img.shields.io/github/downloads/LanKing/flow-launcher-plugin-layout-fallback/total?label=downloads)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

> When I installed Flow Launcher, I was genuinely surprised that I could not find a plugin like this. It made me wonder how much human time has been wasted retyping, deleting, and correcting text entered in the wrong keyboard layout.

# ⌨️ Adds fallback results for wrong keyboard layouts.

![Plugin function demo](/doc/demo.png)

Samples:
* `Yfcnhjqrb` -> additionally searches `Настройки`
* `руддщ` -> additionally searches `hello`

The plugin checks only the keyboard layouts installed in the user's Windows system.

The original Flow Launcher results stay untouched and remain higher. Fallback results are marked with `⌨` and receive a strong score penalty.

<a id="how-it-works"></a>
## 🤓 Mechanics in detail

1. Reads installed Windows keyboard layouts with `GetKeyboardLayoutList`, `HKCU\Keyboard Layout\Preload`, and `HKCU\Keyboard Layout\Substitutes`.
2. Builds conversion maps between every ordered pair of available layouts.
3. Generates corrected query candidates and filters out weak or duplicate conversions.
4. Queries the other global Flow Launcher plugins with the corrected candidates.
5. Appends lower-priority fallback results without touching the original Flow Launcher results.

Explicit action-keyword queries are ignored, so the plugin only participates in ordinary global searches.

<a id="notes"></a>
### 📓 Notes

* Fallback output is limited to 20 results and 6 results per source plugin.
* Latin-to-Latin fallback candidates use a softer filter, but receive an extra score penalty and appear lower.
* Some third-party plugins may behave differently when queried indirectly, so fallback results can vary by source plugin.
* Layout Fallback does not translate or transliterate text. It only reinterprets the same physical key presses through other installed Windows keyboard layouts.

<a id="supported-keyboard-layouts"></a>
## 🌍 Supported keyboard layouts

Layout Fallback works best with direct keyboard layouts where the same physical keys produce different characters.

Best candidates include 🇺🇸 English US, 🇬🇧 English UK, <sub>ru</sub> Russian, 🇺🇦 Ukrainian, 🇧🇾 Belarusian, 🇧🇬 Bulgarian, 🇷🇸 Serbian Cyrillic, 🇲🇰 Macedonian, 🇰🇿 Kazakh, 🇰🇬 Kyrgyz, 🇲🇳 Mongolian Cyrillic, 🇬🇷 Greek, 🇮🇱 Hebrew, 🇸🇦 Arabic, 🇮🇷 Persian, 🇦🇲 Armenian, 🇬🇪 Georgian, 🇹🇭 Thai.

Latin-based layouts may also work, but the benefit is usually smaller because many characters overlap with English. This includes 🇩🇪 German, 🇫🇷 French AZERTY, 🇪🇸 Spanish, 🇮🇹 Italian, 🇵🇹 Portuguese, 🇹🇷 Turkish Q, 🇨🇿 Czech QWERTY, 🇸🇰 Slovak QWERTY, 🇭🇺 Hungarian, 🇷🇴 Romanian, 🇱🇹 Lithuanian, 🇱🇻 Latvian, 🇪🇪 Estonian, 🇭🇷 Croatian, 🇸🇮 Slovenian, 🇦🇱 Albanian, 🇧🇦 Bosnian Latin, 🇷🇸 Serbian Latin, 🇳🇱 Dutch, 🇩🇰 Danish, 🇳🇴 Norwegian, 🇸🇪 Swedish, 🇫🇮 Finnish, 🇮🇸 Icelandic, 🇵🇱 Polish Programmer, 🇵🇱 Polish 214, and 🇵🇱 Polish Typewriter.

Some layouts may have limited support because they rely on IME, dead keys, complex composition, AltGr-heavy input, or candidate selection. This includes 🇨🇳 Chinese Simplified IME, 🇹🇼 Chinese Traditional IME, 🇯🇵 Japanese IME, 🇰🇷 Korean IME, 🇻🇳 Vietnamese Telex, 🇻🇳 Vietnamese VNI, 🇮🇳 Hindi Devanagari input, 🇧🇩 Bengali input, 🇮🇳 Tamil input, 🇮🇳 Telugu input, 🇮🇳 Kannada input, 🇮🇳 Malayalam input, 🇹🇭 Thai Kedmanee variants with complex composition, 🇺🇸 US International, 🇬🇧 United Kingdom Extended, 🇨🇦 Canadian Multilingual Standard, 🇨🇦 French Canadian, 🇪🇸 Spanish International, 🇵🇹 Portuguese ABNT, 🇧🇷 Portuguese ABNT2, 🇨🇿 Czech Programmers, 🇸🇰 Slovak Programmers, 🇭🇺 Hungarian 101-key.

<a id="installation"></a>

## 📦 Installation

If the plugin is available in the Flow Launcher plugin store, install it from Flow Launcher plugin settings.

<a id="manual-installation"></a>

### Manual installation

Type this in Flow Launcher:

```text
pm install https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases/latest/download/LayoutFallback.zip
```

Then restart Flow Launcher by typing `Restart Flow Launcher` and selecting the system command.

<a id="build"></a>
## 🛠 Build

Requires .NET 9 SDK:

```powershell
winget install Microsoft.DotNet.SDK.9
```

Build the plugin:

```powershell
Set-ExecutionPolicy -Scope Process Bypass
.\build.ps1
```

The installable ZIP will be created at:

```text
artifacts\LayoutFallback-0.1.4.zip
```

Install the generated ZIP from Flow Launcher's plugin settings, then restart Flow Launcher.

### Quick local development

You can use a script that builds and copies the build into Flow Launcher, so you don't need to do this manually.

For default Flow Launcher plugins directory:

```powershell
.\install-dev.ps1
```

For portable Flow Launcher or a custom plugins directory:

```powershell
.\install-dev.ps1 -FlowPluginsDirectory "D:\Apps\FlowLauncher\UserData\Plugins"
```

You need to restart Flow Launcher after installation.

## 📄 License

MIT — contributions welcome.
