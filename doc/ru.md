🇺🇦 [Українська](ua.md) | 🇧🇾 [Беларуская](by.md) | 🇧🇬 [Български](bg.md) | 🇷🇸 [Српски](rs.md) | 🇲🇰 [Македонски](mk.md) | 🇰🇿 [Қазақша](kz.md) | 🇰🇬 [Кыргызча](kg.md) | 🇲🇳 [Монгол](mn.md) | 🇬🇷 [Ελληνικά](gr.md) | 🇮🇱 [עברית](il.md) | 🇸🇦 [العربية](sa.md) | 🇮🇷 [فارسی](ir.md) | 🇦🇲 [Հայերեն](am.md) | 🇬🇪 [ქართული](ge.md) | 🇹🇭 [ไทย](th.md)

[![Flow Launcher](https://img.shields.io/badge/Flow%20Launcher-plugin-5c2d91?logo=windows&logoColor=white)](https://www.flowlauncher.com/)
[![Windows](https://img.shields.io/badge/Windows-10%2F11-0078D6?logo=windows&logoColor=white)](https://www.microsoft.com/windows)
[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Latest release](https://img.shields.io/github/v/release/LanKing/flow-launcher-plugin-layout-fallback?label=release)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![Downloads](https://img.shields.io/github/downloads/LanKing/flow-launcher-plugin-layout-fallback/total?label=downloads)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](../LICENSE)

> Когда я установил Flow Launcher, я был искренне удивлён, что не смог найти подобный плагин. Это заставило задуматься, сколько человеческого времени уже было потрачено на повторный набор, удаление и исправление текста, введённого в неправильной раскладке клавиатуры.

# ⌨️ Добавляет fallback-результаты для неправильных раскладок клавиатуры.

![⌨️](/doc/demo.png)

Примеры:
* `Yfcnhjqrb` -> дополнительно ищет `Настройки`
* `руддщ` -> дополнительно ищет `hello`

Плагин проверяет только раскладки клавиатуры, установленные в Windows у пользователя.

Оригинальные результаты Flow Launcher не изменяются и остаются выше. Fallback-результаты помечаются `⌨` и получают сильное понижение score.

<a id="how-it-works"></a>
## 🤓 Механика в деталях

1. Читает установленные раскладки Windows через `GetKeyboardLayoutList`, `HKCU\Keyboard Layout\Preload` и `HKCU\Keyboard Layout\Substitutes`.
2. Строит карты конвертации между каждой упорядоченной парой доступных раскладок.
3. Генерирует исправленные варианты запроса и отфильтровывает слабые или дублирующиеся конверсии.
4. Запрашивает другие глобальные плагины Flow Launcher с исправленными вариантами.
5. Добавляет fallback-результаты с более низким приоритетом, не трогая оригинальные результаты Flow Launcher.

Явные запросы с action keyword игнорируются, поэтому плагин участвует только в обычном глобальном поиске.

<a id="notes"></a>
### 📓 Примечания

* Fallback-вывод ограничен 20 результатами и 6 результатами на исходный плагин.
* Некоторые сторонние плагины могут вести себя иначе при непрямом запросе, поэтому fallback-результаты зависят от исходного плагина.
* Layout Fallback не переводит и не транслитерирует текст. Он только переинтерпретирует те же физические нажатия клавиш через другие установленные раскладки Windows.

<a id="supported-keyboard-layouts"></a>
## 🌍 Поддерживаемые раскладки клавиатуры

Layout Fallback лучше всего работает с прямыми раскладками, где одни и те же физические клавиши дают разные символы.

Лучшие кандидаты включают 🇺🇸 English US, 🇬🇧 English UK, <sub>ru</sub> Russian, 🇺🇦 Ukrainian, 🇧🇾 Belarusian, 🇧🇬 Bulgarian, 🇷🇸 Serbian Cyrillic, 🇲🇰 Macedonian, 🇰🇿 Kazakh, 🇰🇬 Kyrgyz, 🇲🇳 Mongolian Cyrillic, 🇬🇷 Greek, 🇮🇱 Hebrew, 🇸🇦 Arabic, 🇮🇷 Persian, 🇦🇲 Armenian, 🇬🇪 Georgian, 🇹🇭 Thai.

Латинские раскладки тоже могут работать, но польза обычно меньше, потому что многие символы совпадают с английскими. Сюда входят 🇩🇪 German, 🇫🇷 French AZERTY, 🇪🇸 Spanish, 🇮🇹 Italian, 🇵🇹 Portuguese, 🇹🇷 Turkish Q, 🇨🇿 Czech QWERTY, 🇸🇰 Slovak QWERTY, 🇭🇺 Hungarian, 🇷🇴 Romanian, 🇱🇹 Lithuanian, 🇱🇻 Latvian, 🇪🇪 Estonian, 🇭🇷 Croatian, 🇸🇮 Slovenian, 🇦🇱 Albanian, 🇧🇦 Bosnian Latin, 🇷🇸 Serbian Latin, 🇳🇱 Dutch, 🇩🇰 Danish, 🇳🇴 Norwegian, 🇸🇪 Swedish, 🇫🇮 Finnish, 🇮🇸 Icelandic, 🇵🇱 Polish Programmer, 🇵🇱 Polish 214, and 🇵🇱 Polish Typewriter.

Некоторые раскладки могут иметь ограниченную поддержку, потому что используют IME, dead keys, сложную композицию, активный AltGr или выбор кандидатов. Сюда входят 🇨🇳 Chinese Simplified IME, 🇹🇼 Chinese Traditional IME, 🇯🇵 Japanese IME, 🇰🇷 Korean IME, 🇻🇳 Vietnamese Telex, 🇻🇳 Vietnamese VNI, 🇮🇳 Hindi Devanagari input, 🇧🇩 Bengali input, 🇮🇳 Tamil input, 🇮🇳 Telugu input, 🇮🇳 Kannada input, 🇮🇳 Malayalam input, 🇹🇭 Thai Kedmanee variants with complex composition, 🇺🇸 US International, 🇬🇧 United Kingdom Extended, 🇨🇦 Canadian Multilingual Standard, 🇨🇦 French Canadian, 🇪🇸 Spanish International, 🇵🇹 Portuguese ABNT, 🇧🇷 Portuguese ABNT2, 🇨🇿 Czech Programmers, 🇸🇰 Slovak Programmers, 🇭🇺 Hungarian 101-key.

<a id="installation"></a>

## 📦 Установка

Если плагин доступен в магазине плагинов Flow Launcher, установите его через настройки плагинов Flow Launcher.

<a id="manual-installation"></a>

### Ручная установка

Введите это в Flow Launcher:

```text
pm install https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases/latest/download/LayoutFallback.zip
```

Затем перезапустите Flow Launcher: введите `Restart Flow Launcher` и выберите системную команду.

<a id="build"></a>
## 🛠 Сборка

Требуется .NET 9 SDK:

```powershell
winget install Microsoft.DotNet.SDK.9
```

Соберите плагин:

```powershell
Set-ExecutionPolicy -Scope Process Bypass
.\build.ps1
```

Устанавливаемый ZIP будет создан здесь:

```text
artifacts\LayoutFallback-0.1.4.zip
```

Установите сгенерированный ZIP через настройки плагинов Flow Launcher, затем перезапустите Flow Launcher.

### Быстрая локальная разработка

Можно использовать скрипт, который собирает плагин и копирует сборку в Flow Launcher, чтобы не делать это вручную.

Для стандартной папки плагинов Flow Launcher:

```powershell
.\install-dev.ps1
```

Для portable Flow Launcher или своей папки плагинов:

```powershell
.\install-dev.ps1 -FlowPluginsDirectory "D:\Apps\FlowLauncher\UserData\Plugins"
```

После установки нужно перезапустить Flow Launcher.

## 📄 Лицензия

MIT — вклад приветствуется.
