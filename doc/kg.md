🇺🇦 [Українська](ua.md) | <sub>ru</sub> [Русский](ru.md) | 🇧🇾 [Беларуская](by.md) | 🇧🇬 [Български](bg.md) | 🇷🇸 [Српски](rs.md) | 🇲🇰 [Македонски](mk.md) | 🇰🇿 [Қазақша](kz.md) | 🇲🇳 [Монгол](mn.md) | 🇬🇷 [Ελληνικά](gr.md) | 🇮🇱 [עברית](il.md) | 🇸🇦 [العربية](sa.md) | 🇮🇷 [فارسی](ir.md) | 🇦🇲 [Հայերեն](am.md) | 🇬🇪 [ქართული](ge.md) | 🇹🇭 [ไทย](th.md)

[![Flow Launcher](https://img.shields.io/badge/Flow%20Launcher-plugin-5c2d91?logo=windows&logoColor=white)](https://www.flowlauncher.com/)
[![Windows](https://img.shields.io/badge/Windows-10%2F11-0078D6?logo=windows&logoColor=white)](https://www.microsoft.com/windows)
[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Latest release](https://img.shields.io/github/v/release/LanKing/flow-launcher-plugin-layout-fallback?label=release)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![Downloads](https://img.shields.io/github/downloads/LanKing/flow-launcher-plugin-layout-fallback/total?label=downloads)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](../LICENSE)

> Flow Launcher орноткондо, мындай плагинди таба албаганыма чын эле таң калдым. Бул туура эмес клавиатура жайгашуусунда жазылган текстти кайра терүүгө, өчүрүүгө жана оңдоого канча адам убактысы кеткенин ойлондурду.

# ⌨️ Туура эмес клавиатура жайгашуулары үчүн fallback натыйжаларын кошот.

![⌨️](/doc/demo.png)

Мисалдар:
* `:-yl--k-h` -> кошумча издейт `Жөндөөлөр`
* `руддщ` -> кошумча издейт `hello`

Плагин колдонуучунун Windows системасында орнотулган клавиатура жайгашууларын гана текшерет.

Flow Launcherдин баштапкы натыйжалары өзгөрбөйт жана жогоруда калат. Fallback натыйжалары `⌨` менен белгиленип, score катуу төмөндөтүлөт.

<a id="how-it-works"></a>
## 🤓 Механика майда-чүйдөсүнө чейин

1. Windows орнотулган клавиатура жайгашууларын `GetKeyboardLayoutList`, `HKCU\Keyboard Layout\Preload` жана `HKCU\Keyboard Layout\Substitutes` аркылуу окуйт.
2. Ар бир жеткиликтүү жайгашуунун иреттелген жуптарынын ортосунда конвертация карталарын түзөт.
3. Оңдолгон суроо талапкерлерин түзүп, алсыз же кайталанган конвертацияларды алып салат.
4. Оңдолгон талапкерлер менен Flow Launcherдин башка глобалдык плагиндерине суроо жөнөтөт.
5. Flow Launcherдин баштапкы натыйжаларына тийбей, төмөн артыкчылыктуу fallback натыйжаларын кошот.

Action keyword бар ачык суроолор эске алынбайт, ошондуктан плагин жөнөкөй глобалдык издөөдө гана катышат.

<a id="notes"></a>
### 📓 Эскертүүлөр

* Fallback чыгышы 20 натыйжа жана ар бир булак плагинге 6 натыйжа менен чектелген.
* Айрым үчүнчү тарап плагиндери кыйыр суроолордо башкача иштеши мүмкүн, ошондуктан fallback натыйжалары булакка жараша өзгөрүшү мүмкүн.
* Layout Fallback текстти которбойт жана транслитерациялабайт. Ал ошол эле физикалык баскыч басууларын башка орнотулган Windows жайгашуулары аркылуу кайра чечмелейт.

<a id="supported-keyboard-layouts"></a>
## 🌍 Колдоого алынган клавиатура жайгашуулары

Layout Fallback бир эле физикалык баскычтар ар башка белгилерди берген түз клавиатура жайгашуулары менен эң жакшы иштейт.

Эң жакшы талапкерлер: 🇺🇸 English US, 🇬🇧 English UK, <sub>ru</sub> Russian, 🇺🇦 Ukrainian, 🇧🇾 Belarusian, 🇧🇬 Bulgarian, 🇷🇸 Serbian Cyrillic, 🇲🇰 Macedonian, 🇰🇿 Kazakh, 🇰🇬 Kyrgyz, 🇲🇳 Mongolian Cyrillic, 🇬🇷 Greek, 🇮🇱 Hebrew, 🇸🇦 Arabic, 🇮🇷 Persian, 🇦🇲 Armenian, 🇬🇪 Georgian, 🇹🇭 Thai, 🇵🇱 Polish 214, 🇵🇱 Polish Typewriter.

Латын негизиндеги жайгашуулар да иштеши мүмкүн, бирок пайдасы адатта азыраак, анткени көп белгилер англис тили менен дал келет. Булар: 🇩🇪 German, 🇫🇷 French AZERTY, 🇪🇸 Spanish, 🇮🇹 Italian, 🇵🇹 Portuguese, 🇹🇷 Turkish Q, 🇨🇿 Czech QWERTY, 🇸🇰 Slovak QWERTY, 🇭🇺 Hungarian, 🇷🇴 Romanian, 🇱🇹 Lithuanian, 🇱🇻 Latvian, 🇪🇪 Estonian, 🇭🇷 Croatian, 🇸🇮 Slovenian, 🇦🇱 Albanian, 🇧🇦 Bosnian Latin, 🇷🇸 Serbian Latin, 🇳🇱 Dutch, 🇩🇰 Danish, 🇳🇴 Norwegian, 🇸🇪 Swedish, 🇫🇮 Finnish, 🇮🇸 Icelandic.

Кээ бир жайгашууларда колдоо чектелүү болушу мүмкүн, анткени алар IME, dead keys, татаал композиция, AltGrди көп колдонуу же талапкер тандоосуна таянат. Булар: 🇨🇳 Chinese Simplified IME, 🇹🇼 Chinese Traditional IME, 🇯🇵 Japanese IME, 🇰🇷 Korean IME, 🇻🇳 Vietnamese Telex, 🇻🇳 Vietnamese VNI, 🇮🇳 Hindi Devanagari input, 🇧🇩 Bengali input, 🇮🇳 Tamil input, 🇮🇳 Telugu input, 🇮🇳 Kannada input, 🇮🇳 Malayalam input, 🇹🇭 Thai Kedmanee variants with complex composition, 🇺🇸 US International, 🇬🇧 United Kingdom Extended, 🇨🇦 Canadian Multilingual Standard, 🇨🇦 French Canadian, 🇪🇸 Spanish International, 🇵🇹 Portuguese ABNT, 🇧🇷 Portuguese ABNT2, 🇨🇿 Czech Programmers, 🇸🇰 Slovak Programmers, 🇭🇺 Hungarian 101-key, 🇵🇱 Polish Programmer.

<a id="installation"></a>

## 📦 Орнотуу

Эгер плагин Flow Launcher плагиндер дүкөнүндө жеткиликтүү болсо, аны Flow Launcher плагин жөндөөлөрүнөн орнотуңуз.

<a id="manual-installation"></a>

### Кол менен орнотуу

Муну Flow Launcher ичине жазыңыз:

```text
pm install https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases/latest/download/LayoutFallback.zip
```

Андан кийин Flow Launcher'ди кайра иштетиңиз: `Restart Flow Launcher` деп жазып, системалык команданы тандаңыз.

<a id="build"></a>
## 🛠 Чогултуу

.NET 9 SDK керек:

```powershell
winget install Microsoft.DotNet.SDK.9
```

Плагинди чогултуңуз:

```powershell
Set-ExecutionPolicy -Scope Process Bypass
.\build.ps1
```

Орнотула турган ZIP бул жерде түзүлөт:

```text
artifacts\LayoutFallback-0.1.4.zip
```

Түзүлгөн ZIP файлын Flow Launcher плагин жөндөөлөрү аркылуу орнотуңуз, андан кийин Flow Launcher-ди кайра иштетиңиз.

### Ыкчам жергиликтүү иштеп чыгуу

Плагинди чогултуп, build натыйжасын Flow Launcher-ге көчүргөн скриптти колдонсоңуз болот, ошондо муну кол менен кылуунун кереги жок.

Flow Launcher плагиндеринин демейки папкасы үчүн:

```powershell
.\install-dev.ps1
```

Portable Flow Launcher же өз плагиндер папкаңыз үчүн:

```powershell
.\install-dev.ps1 -FlowPluginsDirectory "D:\Apps\FlowLauncher\UserData\Plugins"
```

Орноткондон кийин Flow Launcher-ди кайра иштетүү керек.

## 📄 Лицензия

MIT — салымдар кабыл алынат.
