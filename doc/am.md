🇺🇦 [Українська](ua.md) | <sub>ru</sub> [Русский](ru.md) | 🇧🇾 [Беларуская](by.md) | 🇧🇬 [Български](bg.md) | 🇷🇸 [Српски](rs.md) | 🇲🇰 [Македонски](mk.md) | 🇰🇿 [Қазақша](kz.md) | 🇰🇬 [Кыргызча](kg.md) | 🇲🇳 [Монгол](mn.md) | 🇬🇷 [Ελληνικά](gr.md) | 🇮🇱 [עברית](il.md) | 🇸🇦 [العربية](sa.md) | 🇮🇷 [فارسی](ir.md) | 🇬🇪 [ქართული](ge.md) | 🇹🇭 [ไทย](th.md)

[![Flow Launcher](https://img.shields.io/badge/Flow%20Launcher-plugin-5c2d91?logo=windows&logoColor=white)](https://www.flowlauncher.com/)
[![Windows](https://img.shields.io/badge/Windows-10%2F11-0078D6?logo=windows&logoColor=white)](https://www.microsoft.com/windows)
[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Latest release](https://img.shields.io/github/v/release/LanKing/flow-launcher-plugin-layout-fallback?label=release)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![Downloads](https://img.shields.io/github/downloads/LanKing/flow-launcher-plugin-layout-fallback/total?label=downloads)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](../LICENSE)

> Երբ տեղադրեցի Flow Launcher-ը, անկեղծորեն զարմացա, որ նման plugin չգտա։ Դա ստիպեց մտածել, թե որքան մարդկային ժամանակ է վատնվել սխալ ստեղնաշարի դասավորությամբ մուտքագրված տեքստը նորից գրելու, ջնջելու և ուղղելու վրա։

# ⌨️ Ավելացնում է fallback արդյունքներ սխալ ստեղնաշարի դասավորությունների համար։

![⌨️](/doc/demo.png)

Օրինակներ:
* `Ig'dgsy'yuthf'` -> նաև որոնում է `Կարգավորումներ`
* `հելլո` -> նաև որոնում է `hello`

Plugin-ը ստուգում է միայն օգտագործողի Windows համակարգում տեղադրված ստեղնաշարի դասավորությունները։

Flow Launcher-ի սկզբնական արդյունքները չեն փոխվում և մնում են վերևում։ Fallback արդյունքները նշվում են `⌨`-ով և ստանում են ուժեղ score նվազեցում։

<a id="how-it-works"></a>
## 🤓 Մեխանիկան մանրամասն

1. Կարդում է Windows-ի տեղադրված ստեղնաշարի դասավորությունները՝ `GetKeyboardLayoutList`, `HKCU\Keyboard Layout\Preload` և `HKCU\Keyboard Layout\Substitutes`.
2. Կառուցում է փոխակերպման քարտեզներ հասանելի դասավորությունների յուրաքանչյուր կարգավորված զույգի միջև։
3. Ստեղծում է ուղղված հարցման թեկնածուներ և հեռացնում թույլ կամ կրկնվող փոխակերպումները։
4. Ուղղված թեկնածուներով հարցում է անում Flow Launcher-ի մյուս գլոբալ plugin-ներին։
5. Ավելացնում է ցածր առաջնահերթությամբ fallback արդյունքներ՝ չփոխելով Flow Launcher-ի սկզբնական արդյունքները։

Action keyword-ով բացահայտ հարցումները անտեսվում են, ուստի plugin-ը մասնակցում է միայն սովորական գլոբալ որոնմանը։

<a id="notes"></a>
### 📓 Նշումներ

* Fallback ելքը սահմանափակված է 20 արդյունքով և 6 արդյունքով յուրաքանչյուր աղբյուր plugin-ի համար։
* Որոշ երրորդ կողմի plugin-ներ կարող են տարբեր կերպ վարվել անուղղակի հարցումների դեպքում, ուստի fallback արդյունքները կարող են կախված լինել աղբյուրից։
* Layout Fallback-ը չի թարգմանում և չի տառադարձում տեքստը։ Այն միայն վերաիմաստավորում է նույն ֆիզիկական սեղմումները Windows-ի այլ տեղադրված դասավորություններով։

<a id="supported-keyboard-layouts"></a>
## 🌍 Աջակցվող ստեղնաշարի դասավորություններ

Layout Fallback-ը լավագույնն աշխատում է ուղիղ ստեղնաշարի դասավորությունների հետ, երբ նույն ֆիզիկական ստեղները տալիս են տարբեր նիշեր։

Լավագույն թեկնածուներն են 🇺🇸 English US, 🇬🇧 English UK, <sub>ru</sub> Russian, 🇺🇦 Ukrainian, 🇧🇾 Belarusian, 🇧🇬 Bulgarian, 🇷🇸 Serbian Cyrillic, 🇲🇰 Macedonian, 🇰🇿 Kazakh, 🇰🇬 Kyrgyz, 🇲🇳 Mongolian Cyrillic, 🇬🇷 Greek, 🇮🇱 Hebrew, 🇸🇦 Arabic, 🇮🇷 Persian, 🇦🇲 Armenian, 🇬🇪 Georgian, 🇹🇭 Thai, 🇵🇱 Polish 214, 🇵🇱 Polish Typewriter։

Լատինատառ դասավորությունները նույնպես կարող են աշխատել, բայց օգուտը սովորաբար ավելի փոքր է, քանի որ շատ նշաններ համընկնում են անգլերենի հետ։ Դրանք են՝ 🇩🇪 German, 🇫🇷 French AZERTY, 🇪🇸 Spanish, 🇮🇹 Italian, 🇵🇹 Portuguese, 🇹🇷 Turkish Q, 🇨🇿 Czech QWERTY, 🇸🇰 Slovak QWERTY, 🇭🇺 Hungarian, 🇷🇴 Romanian, 🇱🇹 Lithuanian, 🇱🇻 Latvian, 🇪🇪 Estonian, 🇭🇷 Croatian, 🇸🇮 Slovenian, 🇦🇱 Albanian, 🇧🇦 Bosnian Latin, 🇷🇸 Serbian Latin, 🇳🇱 Dutch, 🇩🇰 Danish, 🇳🇴 Norwegian, 🇸🇪 Swedish, 🇫🇮 Finnish, 🇮🇸 Icelandic։

Որոշ դասավորություններ կարող են ունենալ սահմանափակ աջակցություն, քանի որ հիմնվում են IME-ի, dead keys-ի, բարդ կազմման, AltGr-ի ակտիվ օգտագործման կամ թեկնածուների ընտրության վրա։ Դրանք են՝ 🇨🇳 Chinese Simplified IME, 🇹🇼 Chinese Traditional IME, 🇯🇵 Japanese IME, 🇰🇷 Korean IME, 🇻🇳 Vietnamese Telex, 🇻🇳 Vietnamese VNI, 🇮🇳 Hindi Devanagari input, 🇧🇩 Bengali input, 🇮🇳 Tamil input, 🇮🇳 Telugu input, 🇮🇳 Kannada input, 🇮🇳 Malayalam input, 🇹🇭 Thai Kedmanee variants with complex composition, 🇺🇸 US International, 🇬🇧 United Kingdom Extended, 🇨🇦 Canadian Multilingual Standard, 🇨🇦 French Canadian, 🇪🇸 Spanish International, 🇵🇹 Portuguese ABNT, 🇧🇷 Portuguese ABNT2, 🇨🇿 Czech Programmers, 🇸🇰 Slovak Programmers, 🇭🇺 Hungarian 101-key, 🇵🇱 Polish Programmer։

<a id="installation"></a>

## 📦 Տեղադրում

Եթե plugin-ը հասանելի է Flow Launcher plugin store-ում, տեղադրեք այն Flow Launcher-ի plugin settings-ից։

<a id="manual-installation"></a>

### Ձեռքով տեղադրում

Սա մուտքագրեք Flow Launcher-ում՝

```text
pm install https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases/latest/download/LayoutFallback.zip
```

Այնուհետև վերագործարկեք Flow Launcher-ը՝ մուտքագրելով `Restart Flow Launcher` և ընտրելով system command-ը։

<a id="build"></a>
## 🛠 Build

Պահանջվում է .NET 9 SDK:

```powershell
winget install Microsoft.DotNet.SDK.9
```

Կառուցեք plugin-ը՝

```powershell
Set-ExecutionPolicy -Scope Process Bypass
.\build.ps1
```

Տեղադրվող ZIP-ը կստեղծվի այստեղ՝

```text
artifacts\LayoutFallback-0.1.4.zip
```

Տեղադրեք ստեղծված ZIP-ը Flow Launcher-ի plugin settings-ից, հետո վերագործարկեք Flow Launcher-ը։

### Արագ տեղային մշակում

Կարող եք օգտագործել script, որը կառուցում է plugin-ը և build-ը պատճենում Flow Launcher-ի մեջ, որպեսզի դա ձեռքով չանեք։

Flow Launcher-ի plugin-ների լռելյայն պանակի համար՝

```powershell
.\install-dev.ps1
```

Portable Flow Launcher-ի կամ custom plugins պանակի համար՝

```powershell
.\install-dev.ps1 -FlowPluginsDirectory "D:\Apps\FlowLauncher\UserData\Plugins"
```

Տեղադրումից հետո պետք է վերագործարկել Flow Launcher-ը։

## 📄 Լիցենզիա

MIT — ներդրումները ողջունելի են։
