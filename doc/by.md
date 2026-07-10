🇺🇦 [Українська](ua.md) | <sub>ru</sub> [Русский](ru.md) | 🇧🇬 [Български](bg.md) | 🇷🇸 [Српски](rs.md) | 🇲🇰 [Македонски](mk.md) | 🇰🇿 [Қазақша](kz.md) | 🇰🇬 [Кыргызча](kg.md) | 🇲🇳 [Монгол](mn.md) | 🇬🇷 [Ελληνικά](gr.md) | 🇮🇱 [עברית](il.md) | 🇸🇦 [العربية](sa.md) | 🇮🇷 [فارسی](ir.md) | 🇦🇲 [Հայերեն](am.md) | 🇬🇪 [ქართული](ge.md) | 🇹🇭 [ไทย](th.md)

[![Flow Launcher](https://img.shields.io/badge/Flow%20Launcher-plugin-5c2d91?logo=windows&logoColor=white)](https://www.flowlauncher.com/)
[![Windows](https://img.shields.io/badge/Windows-10%2F11-0078D6?logo=windows&logoColor=white)](https://www.microsoft.com/windows)
[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Latest release](https://img.shields.io/github/v/release/LanKing/flow-launcher-plugin-layout-fallback?label=release)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![Downloads](https://img.shields.io/github/downloads/LanKing/flow-launcher-plugin-layout-fallback/total?label=downloads)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](../LICENSE)

> Калі я ўсталяваў Flow Launcher, мяне сапраўды здзівіла, што я не знайшоў падобнага плагіна. Гэта прымусіла задумацца, колькі чалавечага часу было змарнавана на паўторны набор, выдаленне і выпраўленне тэксту, уведзенага ў няправільнай раскладцы клавіятуры.

# ⌨️ Дадае fallback-вынікі для няправільных раскладак клавіятуры.

![⌨️](/doc/demo.png)

Прыклады:
* `Yfkfls` -> дадаткова шукае `Налады`
* `руддщ` -> дадаткова шукае `hello`

Плагін правярае толькі раскладкі клавіятуры, усталяваныя ў Windows карыстальніка.

Арыгінальныя вынікі Flow Launcher не змяняюцца і застаюцца вышэй. Fallback-вынікі пазначаюцца `⌨` і атрымліваюць моцнае паніжэнне score.

<a id="how-it-works"></a>
## 🤓 Механіка ў дэталях

1. Чытае ўсталяваныя раскладкі Windows праз `GetKeyboardLayoutList`, `HKCU\Keyboard Layout\Preload` і `HKCU\Keyboard Layout\Substitutes`.
2. Будуе карты канвертацыі паміж кожнай упарадкаванай парай даступных раскладак.
3. Генеруе выпраўленыя кандыдаты запыту і адфільтроўвае слабыя або дубляваныя канверсіі.
4. Запытвае іншыя глабальныя плагіны Flow Launcher з выпраўленымі кандыдатамі.
5. Дадае fallback-вынікі з ніжэйшым прыярытэтам, не змяняючы арыгінальныя вынікі Flow Launcher.

Яўныя запыты з action keyword ігнаруюцца, таму плагін удзельнічае толькі ў звычайным глабальным пошуку.

<a id="notes"></a>
### 📓 Заўвагі

* Fallback-вынікі абмежаваныя 20 вынікамі і 6 вынікамі на зыходны плагін.
* Некаторыя староннія плагіны могуць паводзіць сябе інакш пры ўскосным запыце, таму fallback-вынікі могуць залежаць ад зыходнага плагіна.
* Layout Fallback не перакладае і не транслітэруе тэкст. Ён толькі пераінтэрпрэтуе тыя ж фізічныя націскі клавіш праз іншыя ўсталяваныя раскладкі Windows.

<a id="supported-keyboard-layouts"></a>
## 🌍 Падтрыманыя раскладкі клавіятуры

Layout Fallback лепш за ўсё працуе з прамымі раскладкамі, дзе адны і тыя ж фізічныя клавішы даюць розныя сімвалы.

Найлепшыя кандыдаты ўключаюць 🇺🇸 English US, 🇬🇧 English UK, 🇷🇺 Russian, 🇺🇦 Ukrainian, 🇧🇾 Belarusian, 🇧🇬 Bulgarian, 🇷🇸 Serbian Cyrillic, 🇲🇰 Macedonian, 🇰🇿 Kazakh, 🇰🇬 Kyrgyz, 🇲🇳 Mongolian Cyrillic, 🇬🇷 Greek, 🇮🇱 Hebrew, 🇸🇦 Arabic, 🇮🇷 Persian, 🇦🇲 Armenian, 🇬🇪 Georgian, 🇹🇭 Thai.

Лацінскія раскладкі таксама могуць працаваць, але карысць звычайна меншая, бо шмат сімвалаў супадае з англійскімі. Сюды ўваходзяць 🇩🇪 German, 🇫🇷 French AZERTY, 🇪🇸 Spanish, 🇮🇹 Italian, 🇵🇹 Portuguese, 🇹🇷 Turkish Q, 🇨🇿 Czech QWERTY, 🇸🇰 Slovak QWERTY, 🇭🇺 Hungarian, 🇷🇴 Romanian, 🇱🇹 Lithuanian, 🇱🇻 Latvian, 🇪🇪 Estonian, 🇭🇷 Croatian, 🇸🇮 Slovenian, 🇦🇱 Albanian, 🇧🇦 Bosnian Latin, 🇷🇸 Serbian Latin, 🇳🇱 Dutch, 🇩🇰 Danish, 🇳🇴 Norwegian, 🇸🇪 Swedish, 🇫🇮 Finnish, 🇮🇸 Icelandic, 🇵🇱 Polish Programmer, 🇵🇱 Polish 214, and 🇵🇱 Polish Typewriter.

Некаторыя раскладкі могуць мець абмежаваную падтрымку, бо выкарыстоўваюць IME, dead keys, складаную кампазіцыю, AltGr або выбар кандыдатаў. Сюды ўваходзяць 🇨🇳 Chinese Simplified IME, 🇹🇼 Chinese Traditional IME, 🇯🇵 Japanese IME, 🇰🇷 Korean IME, 🇻🇳 Vietnamese Telex, 🇻🇳 Vietnamese VNI, 🇮🇳 Hindi Devanagari input, 🇧🇩 Bengali input, 🇮🇳 Tamil input, 🇮🇳 Telugu input, 🇮🇳 Kannada input, 🇮🇳 Malayalam input, 🇹🇭 Thai Kedmanee variants with complex composition, 🇺🇸 US International, 🇬🇧 United Kingdom Extended, 🇨🇦 Canadian Multilingual Standard, 🇨🇦 French Canadian, 🇪🇸 Spanish International, 🇵🇹 Portuguese ABNT, 🇧🇷 Portuguese ABNT2, 🇨🇿 Czech Programmers, 🇸🇰 Slovak Programmers, 🇭🇺 Hungarian 101-key.

<a id="installation"></a>

## 📦 Усталяванне

Калі плагін даступны ў краме плагінаў Flow Launcher, усталюйце яго праз налады плагінаў Flow Launcher.

<a id="manual-installation"></a>

### Ручное ўсталяванне

Увядзіце гэта ў Flow Launcher:

```text
pm install https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases/latest/download/LayoutFallback.zip
```

Пасля гэтага перазапусціце Flow Launcher: увядзіце `Restart Flow Launcher` і выберыце сістэмную каманду.

<a id="build"></a>
## 🛠 Зборка

Патрэбны .NET 9 SDK:

```powershell
winget install Microsoft.DotNet.SDK.9
```

Збярыце плагін:

```powershell
Set-ExecutionPolicy -Scope Process Bypass
.\build.ps1
```

ZIP для ўсталявання будзе створаны тут:

```text
artifacts\LayoutFallback-0.1.4.zip
```

Усталюйце згенераваны ZIP праз налады плагінаў Flow Launcher, потым перазапусціце Flow Launcher.

### Хуткая лакальная распрацоўка

Можна выкарыстаць скрыпт, які збірае плагін і капіюе зборку ў Flow Launcher, каб не рабіць гэта ўручную.

Для стандартнай папкі плагінаў Flow Launcher:

```powershell
.\install-dev.ps1
```

Для portable Flow Launcher або ўласнай папкі плагінаў:

```powershell
.\install-dev.ps1 -FlowPluginsDirectory "D:\Apps\FlowLauncher\UserData\Plugins"
```

Пасля ўсталявання трэба перазапусціць Flow Launcher.

## 📄 Ліцэнзія

MIT — унёскі вітаюцца.
