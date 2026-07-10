🇺🇦 [Українська](ua.md) | 🇷🇺 [Русский](ru.md) | 🇧🇾 [Беларуская](by.md) | 🇧🇬 [Български](bg.md) | 🇲🇰 [Македонски](mk.md) | 🇰🇿 [Қазақша](kz.md) | 🇰🇬 [Кыргызча](kg.md) | 🇲🇳 [Монгол](mn.md) | 🇬🇷 [Ελληνικά](gr.md) | 🇮🇱 [עברית](il.md) | 🇸🇦 [العربية](sa.md) | 🇮🇷 [فارسی](ir.md) | 🇦🇲 [Հայերեն](am.md) | 🇬🇪 [ქართული](ge.md) | 🇹🇭 [ไทย](th.md)

[![Flow Launcher](https://img.shields.io/badge/Flow%20Launcher-plugin-5c2d91?logo=windows&logoColor=white)](https://www.flowlauncher.com/)
[![Windows](https://img.shields.io/badge/Windows-10%2F11-0078D6?logo=windows&logoColor=white)](https://www.microsoft.com/windows)
[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Latest release](https://img.shields.io/github/v/release/LanKing/flow-launcher-plugin-layout-fallback?label=release)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![Downloads](https://img.shields.io/github/downloads/LanKing/flow-launcher-plugin-layout-fallback/total?label=downloads)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](../LICENSE)

> Када сам инсталирао Flow Launcher, искрено ме је изненадило што нисам нашао овакав додатак. Натерало ме је да размислим колико је људског времена потрошено на поновно куцање, брисање и исправљање текста унетог у погрешном распореду тастатуре.

# ⌨️ Додаје fallback резултате за погрешне распореде тастатуре.

![⌨️](/doc/demo.png)

Примери:
* `Pode[avawa` -> дополнительно ищет `Подешавања`
* `хелло` -> дополнительно ищет `hello`

Плагин проверава само распореде тастатуре инсталиране у корисниковом Windows систему.

Оригинални резултати Flow Launcher-а остају нетакнути и остају више. Fallback резултати су означени са `⌨` и добијају снажно снижење score-а.

<a id="how-it-works"></a>
## 🤓 Механика у детаљима

1. Чита инсталиране распореде тастатуре Windows-а преко `GetKeyboardLayoutList`, `HKCU\Keyboard Layout\Preload` и `HKCU\Keyboard Layout\Substitutes`.
2. Гради мапе конверзије између сваког уређеног пара доступних распореда.
3. Генерише исправљене кандидате упита и уклања слабе или дуплиране конверзије.
4. Пита друге глобалне додатке Flow Launcher-а исправљеним кандидатима.
5. Додаје fallback резултате нижег приоритета без додиривања оригиналних резултата Flow Launcher-а.

Експлицитни упити са action keyword се игноришу, па додатак учествује само у обичној глобалној претрази.

<a id="notes"></a>
### 📓 Напомене

* Fallback излаз је ограничен на 20 резултата и 6 резултата по изворном додатку.
* Неки додаци трећих страна могу се понашати другачије при индиректним упитима, па fallback резултати могу зависити од извора.
* Layout Fallback не преводи и не транслитерише текст. Само поново тумачи исте физичке притиске тастера кроз друге инсталиране Windows распореде.

<a id="supported-keyboard-layouts"></a>
## 🌍 Подржани распореди тастатуре

Layout Fallback најбоље ради са директним распоредима тастатуре, где исте физичке типке дају различите знакове.

Најбољи кандидати су 🇺🇸 English US, 🇬🇧 English UK, 🇷🇺 Russian, 🇺🇦 Ukrainian, 🇧🇾 Belarusian, 🇧🇬 Bulgarian, 🇷🇸 Serbian Cyrillic, 🇲🇰 Macedonian, 🇰🇿 Kazakh, 🇰🇬 Kyrgyz, 🇲🇳 Mongolian Cyrillic, 🇬🇷 Greek, 🇮🇱 Hebrew, 🇸🇦 Arabic, 🇮🇷 Persian, 🇦🇲 Armenian, 🇬🇪 Georgian, 🇹🇭 Thai, 🇵🇱 Polish 214, 🇵🇱 Polish Typewriter.

Латинични распореди такође могу да раде, али је корист обично мања јер се многи знакови преклапају са енглеским. То укључује: 🇩🇪 German, 🇫🇷 French AZERTY, 🇪🇸 Spanish, 🇮🇹 Italian, 🇵🇹 Portuguese, 🇹🇷 Turkish Q, 🇨🇿 Czech QWERTY, 🇸🇰 Slovak QWERTY, 🇭🇺 Hungarian, 🇷🇴 Romanian, 🇱🇹 Lithuanian, 🇱🇻 Latvian, 🇪🇪 Estonian, 🇭🇷 Croatian, 🇸🇮 Slovenian, 🇦🇱 Albanian, 🇧🇦 Bosnian Latin, 🇷🇸 Serbian Latin, 🇳🇱 Dutch, 🇩🇰 Danish, 🇳🇴 Norwegian, 🇸🇪 Swedish, 🇫🇮 Finnish, 🇮🇸 Icelandic.

Неки распореди могу имати ограничену подршку јер користе IME, dead keys, сложену композицију, интензиван AltGr или избор кандидата. То укључује: 🇨🇳 Chinese Simplified IME, 🇹🇼 Chinese Traditional IME, 🇯🇵 Japanese IME, 🇰🇷 Korean IME, 🇻🇳 Vietnamese Telex, 🇻🇳 Vietnamese VNI, 🇮🇳 Hindi Devanagari input, 🇧🇩 Bengali input, 🇮🇳 Tamil input, 🇮🇳 Telugu input, 🇮🇳 Kannada input, 🇮🇳 Malayalam input, 🇹🇭 Thai Kedmanee variants with complex composition, 🇺🇸 US International, 🇬🇧 United Kingdom Extended, 🇨🇦 Canadian Multilingual Standard, 🇨🇦 French Canadian, 🇪🇸 Spanish International, 🇵🇹 Portuguese ABNT, 🇧🇷 Portuguese ABNT2, 🇨🇿 Czech Programmers, 🇸🇰 Slovak Programmers, 🇭🇺 Hungarian 101-key, 🇵🇱 Polish Programmer.

<a id="build"></a>
## 🛠 Изградња

Потребан је .NET 9 SDK:

```powershell
winget install Microsoft.DotNet.SDK.9
```

Изградите плагин:

```powershell
Set-ExecutionPolicy -Scope Process Bypass
.\build.ps1
```

ZIP за инсталацију биће направљен овде:

```text
artifacts\LayoutFallback-0.1.4.zip
```

Инсталирајте генерисани ZIP из подешавања плагина у Flow Launcher-у, затим поново покрените Flow Launcher.

### Брз локални развој

Можете користити скрипту која изгради плагин и копира build у Flow Launcher, да то не радите ручно.

За подразумевану фасциклу плагина Flow Launcher-а:

```powershell
.\install-dev.ps1
```

За portable Flow Launcher или прилагођену фасциклу плагина:

```powershell
.\install-dev.ps1 -FlowPluginsDirectory "D:\Apps\FlowLauncher\UserData\Plugins"
```

После инсталације треба поново покренути Flow Launcher.

## 📄 Лиценца

MIT — доприноси су добродошли.
