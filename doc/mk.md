🇺🇦 [Українська](ua.md) | 🇷🇺 [Русский](ru.md) | 🇧🇾 [Беларуская](by.md) | 🇧🇬 [Български](bg.md) | 🇷🇸 [Српски](rs.md) | 🇰🇿 [Қазақша](kz.md) | 🇰🇬 [Кыргызча](kg.md) | 🇲🇳 [Монгол](mn.md) | 🇬🇷 [Ελληνικά](gr.md) | 🇮🇱 [עברית](il.md) | 🇸🇦 [العربية](sa.md) | 🇮🇷 [فارسی](ir.md) | 🇦🇲 [Հայերեն](am.md) | 🇬🇪 [ქართული](ge.md) | 🇹🇭 [ไทย](th.md)

[![Flow Launcher](https://img.shields.io/badge/Flow%20Launcher-plugin-5c2d91?logo=windows&logoColor=white)](https://www.flowlauncher.com/)
[![Windows](https://img.shields.io/badge/Windows-10%2F11-0078D6?logo=windows&logoColor=white)](https://www.microsoft.com/windows)
[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Latest release](https://img.shields.io/github/v/release/LanKing/flow-launcher-plugin-layout-fallback?label=release)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![Downloads](https://img.shields.io/github/downloads/LanKing/flow-launcher-plugin-layout-fallback/total?label=downloads)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](../LICENSE)

> Кога го инсталирав Flow Launcher, навистина се изненадив што не најдов ваков приклучок. Ме натера да размислам колку човечко време е потрошено на повторно пишување, бришење и корекција на текст внесен со погрешен распоред на тастатура.

# ⌨️ Додава fallback резултати за погрешни распореди на тастатура.

![⌨️](/doc/demo.png)

Примери:
* `Postavki` -> дополнително пребарува `Поставки`
* `хелло` -> дополнително пребарува `hello`

Приклучокот ги проверува само распоредите на тастатура инсталирани во Windows системот на корисникот.

Оригиналните резултати на Flow Launcher не се менуваат и остануваат повисоко. Fallback резултатите се означуваат со `⌨` и добиваат силно намалување на score.

<a id="how-it-works"></a>
## 🤓 Механика во детали

1. Чита инсталирани распореди на тастатура Windows преку `GetKeyboardLayoutList`, `HKCU\Keyboard Layout\Preload` и `HKCU\Keyboard Layout\Substitutes`.
2. Гради карти за конверзија меѓу секој уреден пар достапни распореди.
3. Генерира коригирани кандидати за барање и ги отстранува слабите или дуплираните конверзии.
4. Ги прашува другите глобални приклучоци на Flow Launcher со коригираните кандидати.
5. Додава fallback резултати со понизок приоритет без да ги допира оригиналните резултати на Flow Launcher.

Јасните барања со action keyword се игнорираат, па приклучокот учествува само во обично глобално пребарување.

<a id="notes"></a>
### 📓 Белешки

* Fallback излезот е ограничен на 20 резултати и 6 резултати по изворен приклучок.
* Некои приклучоци од трети страни може да се однесуваат поинаку при индиректни барања, па fallback резултатите може да зависат од изворот.
* Layout Fallback не преведува и не транслитерира текст. Само ги преинтерпретира истите физички притискања на копчиња преку други инсталирани Windows распореди.

<a id="supported-keyboard-layouts"></a>
## 🌍 Поддржани распореди на тастатура

Layout Fallback најдобро работи со директни распореди на тастатура, каде истите физички копчиња даваат различни знаци.

Најдобри кандидати се 🇺🇸 English US, 🇬🇧 English UK, 🇷🇺 Russian, 🇺🇦 Ukrainian, 🇧🇾 Belarusian, 🇧🇬 Bulgarian, 🇷🇸 Serbian Cyrillic, 🇲🇰 Macedonian, 🇰🇿 Kazakh, 🇰🇬 Kyrgyz, 🇲🇳 Mongolian Cyrillic, 🇬🇷 Greek, 🇮🇱 Hebrew, 🇸🇦 Arabic, 🇮🇷 Persian, 🇦🇲 Armenian, 🇬🇪 Georgian, 🇹🇭 Thai, 🇵🇱 Polish 214, 🇵🇱 Polish Typewriter.

Латинските распореди исто така може да работат, но користа обично е помала бидејќи многу знаци се поклопуваат со англискиот. Ова вклучува: 🇩🇪 German, 🇫🇷 French AZERTY, 🇪🇸 Spanish, 🇮🇹 Italian, 🇵🇹 Portuguese, 🇹🇷 Turkish Q, 🇨🇿 Czech QWERTY, 🇸🇰 Slovak QWERTY, 🇭🇺 Hungarian, 🇷🇴 Romanian, 🇱🇹 Lithuanian, 🇱🇻 Latvian, 🇪🇪 Estonian, 🇭🇷 Croatian, 🇸🇮 Slovenian, 🇦🇱 Albanian, 🇧🇦 Bosnian Latin, 🇷🇸 Serbian Latin, 🇳🇱 Dutch, 🇩🇰 Danish, 🇳🇴 Norwegian, 🇸🇪 Swedish, 🇫🇮 Finnish, 🇮🇸 Icelandic.

Некои распореди може да имаат ограничена поддршка бидејќи користат IME, dead keys, сложена композиција, активен AltGr или избор на кандидати. Ова вклучува: 🇨🇳 Chinese Simplified IME, 🇹🇼 Chinese Traditional IME, 🇯🇵 Japanese IME, 🇰🇷 Korean IME, 🇻🇳 Vietnamese Telex, 🇻🇳 Vietnamese VNI, 🇮🇳 Hindi Devanagari input, 🇧🇩 Bengali input, 🇮🇳 Tamil input, 🇮🇳 Telugu input, 🇮🇳 Kannada input, 🇮🇳 Malayalam input, 🇹🇭 Thai Kedmanee variants with complex composition, 🇺🇸 US International, 🇬🇧 United Kingdom Extended, 🇨🇦 Canadian Multilingual Standard, 🇨🇦 French Canadian, 🇪🇸 Spanish International, 🇵🇹 Portuguese ABNT, 🇧🇷 Portuguese ABNT2, 🇨🇿 Czech Programmers, 🇸🇰 Slovak Programmers, 🇭🇺 Hungarian 101-key, 🇵🇱 Polish Programmer.

<a id="build"></a>
## 🛠 Градење

Потребен е .NET 9 SDK:

```powershell
winget install Microsoft.DotNet.SDK.9
```

Изградете го приклучокот:

```powershell
Set-ExecutionPolicy -Scope Process Bypass
.\build.ps1
```

ZIP-от за инсталација ќе биде создаден тука:

```text
artifactsayoutfallback.zip
```

Инсталирајте го генерираниот ZIP преку поставките за приклучоци на Flow Launcher, потоа рестартирајте го Flow Launcher.

### Брз локален развој

Може да користите скрипта што го гради приклучокот и ја копира градбата во Flow Launcher, за да не го правите тоа рачно.

За стандардната папка со приклучоци на Flow Launcher:

```powershell
.\install-dev.ps1
```

За portable Flow Launcher или сопствена папка со приклучоци:

```powershell
.\install-dev.ps1 -FlowPluginsDirectory "D:\Apps\FlowLauncher\UserData\Plugins"
```

По инсталацијата треба да го рестартирате Flow Launcher.

## 📄 Лиценца

MIT — придонесите се добредојдени.
