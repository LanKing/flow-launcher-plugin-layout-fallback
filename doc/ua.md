🇷🇺 [Русский](ru.md) | 🇧🇾 [Беларуская](by.md) | 🇧🇬 [Български](bg.md) | 🇷🇸 [Српски](rs.md) | 🇲🇰 [Македонски](mk.md) | 🇰🇿 [Қазақша](kz.md) | 🇰🇬 [Кыргызча](kg.md) | 🇲🇳 [Монгол](mn.md) | 🇬🇷 [Ελληνικά](gr.md) | 🇮🇱 [עברית](il.md) | 🇸🇦 [العربية](sa.md) | 🇮🇷 [فارسی](ir.md) | 🇦🇲 [Հայերեն](am.md) | 🇬🇪 [ქართული](ge.md) | 🇹🇭 [ไทย](th.md)

[![Flow Launcher](https://img.shields.io/badge/Flow%20Launcher-plugin-5c2d91?logo=windows&logoColor=white)](https://www.flowlauncher.com/)
[![Windows](https://img.shields.io/badge/Windows-10%2F11-0078D6?logo=windows&logoColor=white)](https://www.microsoft.com/windows)
[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Latest release](https://img.shields.io/github/v/release/LanKing/flow-launcher-plugin-layout-fallback?label=release)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![Downloads](https://img.shields.io/github/downloads/LanKing/flow-launcher-plugin-layout-fallback/total?label=downloads)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](../LICENSE)

> Коли я встановив Flow Launcher, я щиро здивувався, що не зміг знайти подібний плагін. Це змусило мене замислитися, скільки людського часу вже було витрачено на повторне введення, видалення та виправлення тексту, набраного в неправильній розкладці клавіатури.

# ⌨️ Додає fallback-результати для неправильних розкладок клавіатури.

![⌨️](/doc/demo.png)

Приклади:
* `Yfkfinedfyyz` -> додатково шукає `Налаштування`
* `руддщ` -> додатково шукає `hello`

Плагін перевіряє лише розкладки клавіатури, встановлені у Windows користувача.

Оригінальні результати Flow Launcher не змінюються та залишаються вище. Fallback-результати позначаються `⌨` і отримують сильне зниження score.

<a id="how-it-works"></a>
## 🤓 Механіка в деталях

1. Читає встановлені розкладки Windows через `GetKeyboardLayoutList`, `HKCU\Keyboard Layout\Preload` та `HKCU\Keyboard Layout\Substitutes`.
2. Будує карти конвертації між кожною впорядкованою парою доступних розкладок.
3. Генерує виправлені варіанти запиту та відфільтровує слабкі або дубльовані конверсії.
4. Запитує інші глобальні плагіни Flow Launcher з виправленими варіантами.
5. Додає fallback-результати з нижчим пріоритетом, не змінюючи оригінальні результати Flow Launcher.

Явні запити з action keyword ігноруються, тому плагін бере участь лише у звичайному глобальному пошуку.

<a id="notes"></a>
### 📓 Примітки

* Fallback-вивід обмежено 20 результатами та 6 результатами на вихідний плагін.
* Деякі сторонні плагіни можуть поводитися інакше при непрямому запиті, тому fallback-результати можуть відрізнятися залежно від джерела.
* Layout Fallback не перекладає і не транслітерує текст. Він лише переінтерпретовує ті самі фізичні натискання клавіш через інші встановлені розкладки Windows.

<a id="supported-keyboard-layouts"></a>
## 🌍 Підтримувані розкладки клавіатури

Layout Fallback найкраще працює з прямими розкладками, де ті самі фізичні клавіші дають різні символи.

Найкращі кандидати включають 🇺🇸 English US, 🇬🇧 English UK, 🇷🇺 Russian, 🇺🇦 Ukrainian, 🇧🇾 Belarusian, 🇧🇬 Bulgarian, 🇷🇸 Serbian Cyrillic, 🇲🇰 Macedonian, 🇰🇿 Kazakh, 🇰🇬 Kyrgyz, 🇲🇳 Mongolian Cyrillic, 🇬🇷 Greek, 🇮🇱 Hebrew, 🇸🇦 Arabic, 🇮🇷 Persian, 🇦🇲 Armenian, 🇬🇪 Georgian, 🇹🇭 Thai.

Латинські розкладки також можуть працювати, але користь зазвичай менша, бо багато символів збігаються з англійськими. Сюди входять 🇩🇪 German, 🇫🇷 French AZERTY, 🇪🇸 Spanish, 🇮🇹 Italian, 🇵🇹 Portuguese, 🇹🇷 Turkish Q, 🇨🇿 Czech QWERTY, 🇸🇰 Slovak QWERTY, 🇭🇺 Hungarian, 🇷🇴 Romanian, 🇱🇹 Lithuanian, 🇱🇻 Latvian, 🇪🇪 Estonian, 🇭🇷 Croatian, 🇸🇮 Slovenian, 🇦🇱 Albanian, 🇧🇦 Bosnian Latin, 🇷🇸 Serbian Latin, 🇳🇱 Dutch, 🇩🇰 Danish, 🇳🇴 Norwegian, 🇸🇪 Swedish, 🇫🇮 Finnish, 🇮🇸 Icelandic, 🇵🇱 Polish Programmer, 🇵🇱 Polish 214, and 🇵🇱 Polish Typewriter.

Деякі розкладки можуть мати обмежену підтримку, бо використовують IME, dead keys, складну композицію, AltGr або вибір кандидатів. Сюди входять 🇨🇳 Chinese Simplified IME, 🇹🇼 Chinese Traditional IME, 🇯🇵 Japanese IME, 🇰🇷 Korean IME, 🇻🇳 Vietnamese Telex, 🇻🇳 Vietnamese VNI, 🇮🇳 Hindi Devanagari input, 🇧🇩 Bengali input, 🇮🇳 Tamil input, 🇮🇳 Telugu input, 🇮🇳 Kannada input, 🇮🇳 Malayalam input, 🇹🇭 Thai Kedmanee variants with complex composition, 🇺🇸 US International, 🇬🇧 United Kingdom Extended, 🇨🇦 Canadian Multilingual Standard, 🇨🇦 French Canadian, 🇪🇸 Spanish International, 🇵🇹 Portuguese ABNT, 🇧🇷 Portuguese ABNT2, 🇨🇿 Czech Programmers, 🇸🇰 Slovak Programmers, 🇭🇺 Hungarian 101-key.

<a id="build"></a>
## 🛠 Збірка

Потрібен .NET 9 SDK:

```powershell
winget install Microsoft.DotNet.SDK.9
```

Зберіть плагін:

```powershell
Set-ExecutionPolicy -Scope Process Bypass
.\build.ps1
```

ZIP для встановлення буде створено тут:

```text
artifactsayoutfallback.zip
```

Встановіть згенерований ZIP через налаштування плагінів Flow Launcher, а потім перезапустіть Flow Launcher.

### Швидка локальна розробка

Можна скористатися скриптом, який збирає плагін і копіює збірку у Flow Launcher, щоб не робити це вручну.

Для стандартної папки плагінів Flow Launcher:

```powershell
.\install-dev.ps1
```

Для portable Flow Launcher або власної папки плагінів:

```powershell
.\install-dev.ps1 -FlowPluginsDirectory "D:\Apps\FlowLauncher\UserData\Plugins"
```

Після встановлення потрібно перезапустити Flow Launcher.

## 📄 Ліцензія

MIT — внески вітаються.
