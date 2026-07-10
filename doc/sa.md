🇺🇦 [Українська](ua.md) | <sub>ru</sub> [Русский](ru.md) | 🇧🇾 [Беларуская](by.md) | 🇧🇬 [Български](bg.md) | 🇷🇸 [Српски](rs.md) | 🇲🇰 [Македонски](mk.md) | 🇰🇿 [Қазақша](kz.md) | 🇰🇬 [Кыргызча](kg.md) | 🇲🇳 [Монгол](mn.md) | 🇬🇷 [Ελληνικά](gr.md) | 🇮🇱 [עברית](il.md) | 🇮🇷 [فارسی](ir.md) | 🇦🇲 [Հայերեն](am.md) | 🇬🇪 [ქართული](ge.md) | 🇹🇭 [ไทย](th.md)

[![Flow Launcher](https://img.shields.io/badge/Flow%20Launcher-plugin-5c2d91?logo=windows&logoColor=white)](https://www.flowlauncher.com/)
[![Windows](https://img.shields.io/badge/Windows-10%2F11-0078D6?logo=windows&logoColor=white)](https://www.microsoft.com/windows)
[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Latest release](https://img.shields.io/github/v/release/LanKing/flow-launcher-plugin-layout-fallback?label=release)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![Downloads](https://img.shields.io/github/downloads/LanKing/flow-launcher-plugin-layout-fallback/total?label=downloads)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](../LICENSE)

> عندما ثبّتُّ Flow Launcher، فوجئت حقًا بأنني لم أجد إضافة مثل هذه. جعلني ذلك أفكر في مقدار الوقت البشري الذي ضاع في إعادة الكتابة والحذف وتصحيح نص كُتب باستخدام تخطيط لوحة مفاتيح غير صحيح.

# ⌨️ يضيف نتائج fallback لتخطيطات لوحة مفاتيح خاطئة.

![⌨️](/doc/demo.png)

أمثلة:
* `hgYu]h]hj` -> يبحث أيضًا عن `الإعدادات`
* `اثممخ` -> يبحث أيضًا عن `hello`

تتحقق الإضافة فقط من تخطيطات لوحة المفاتيح المثبتة في نظام Windows لدى المستخدم.

تبقى نتائج Flow Launcher الأصلية كما هي وتظل أعلى. تُعلَّم نتائج fallback بالرمز `⌨` وتحصل على خفض قوي في score.

<a id="how-it-works"></a>
## 🤓 آلية العمل بالتفصيل

1. يقرأ تخطيطات لوحة مفاتيح Windows المثبتة باستخدام `GetKeyboardLayoutList`, `HKCU\Keyboard Layout\Preload` و `HKCU\Keyboard Layout\Substitutes`.
2. يبني خرائط تحويل بين كل زوج مرتب من التخطيطات المتاحة.
3. ينشئ مرشحات استعلام مصححة ويستبعد التحويلات الضعيفة أو المكررة.
4. يستعلم إضافات Flow Launcher العالمية الأخرى بالمرشحات المصححة.
5. يضيف نتائج fallback بأولوية أقل دون لمس نتائج Flow Launcher الأصلية.

يتم تجاهل الاستعلامات الصريحة ذات action keyword، لذلك تشارك الإضافة فقط في البحث العالمي العادي.

<a id="notes"></a>
### 📓 ملاحظات

* مخرجات fallback محدودة بـ 20 نتيجة و6 نتائج لكل إضافة مصدر.
* قد تتصرف بعض إضافات الطرف الثالث بشكل مختلف عند الاستعلام غير المباشر، لذلك قد تختلف نتائج fallback حسب المصدر.
* Layout Fallback لا يترجم النص ولا ينقله صوتيًا. إنه يعيد فقط تفسير ضغطات المفاتيح الفعلية نفسها عبر تخطيطات Windows أخرى مثبتة.

<a id="supported-keyboard-layouts"></a>
## 🌍 تخطيطات لوحة المفاتيح المدعومة

يعمل Layout Fallback بأفضل شكل مع تخطيطات لوحة المفاتيح المباشرة، حيث تنتج المفاتيح الفعلية نفسها أحرفًا مختلفة.

أفضل المرشحين هم 🇺🇸 English US, 🇬🇧 English UK, 🇷🇺 Russian, 🇺🇦 Ukrainian, 🇧🇾 Belarusian, 🇧🇬 Bulgarian, 🇷🇸 Serbian Cyrillic, 🇲🇰 Macedonian, 🇰🇿 Kazakh, 🇰🇬 Kyrgyz, 🇲🇳 Mongolian Cyrillic, 🇬🇷 Greek, 🇮🇱 Hebrew, 🇸🇦 Arabic, 🇮🇷 Persian, 🇦🇲 Armenian, 🇬🇪 Georgian, 🇹🇭 Thai, 🇵🇱 Polish 214, 🇵🇱 Polish Typewriter.

يمكن أن تعمل التخطيطات المبنية على اللاتينية أيضًا، لكن الفائدة عادة أقل لأن كثيرًا من الأحرف تتداخل مع الإنجليزية. يشمل ذلك: 🇩🇪 German, 🇫🇷 French AZERTY, 🇪🇸 Spanish, 🇮🇹 Italian, 🇵🇹 Portuguese, 🇹🇷 Turkish Q, 🇨🇿 Czech QWERTY, 🇸🇰 Slovak QWERTY, 🇭🇺 Hungarian, 🇷🇴 Romanian, 🇱🇹 Lithuanian, 🇱🇻 Latvian, 🇪🇪 Estonian, 🇭🇷 Croatian, 🇸🇮 Slovenian, 🇦🇱 Albanian, 🇧🇦 Bosnian Latin, 🇷🇸 Serbian Latin, 🇳🇱 Dutch, 🇩🇰 Danish, 🇳🇴 Norwegian, 🇸🇪 Swedish, 🇫🇮 Finnish, 🇮🇸 Icelandic.

قد يكون لبعض التخطيطات دعم محدود لأنها تعتمد على IME أو المفاتيح الميتة أو التركيب المعقد أو الاستخدام المكثف لـ AltGr أو اختيار المرشحين. يشمل ذلك: 🇨🇳 Chinese Simplified IME, 🇹🇼 Chinese Traditional IME, 🇯🇵 Japanese IME, 🇰🇷 Korean IME, 🇻🇳 Vietnamese Telex, 🇻🇳 Vietnamese VNI, 🇮🇳 Hindi Devanagari input, 🇧🇩 Bengali input, 🇮🇳 Tamil input, 🇮🇳 Telugu input, 🇮🇳 Kannada input, 🇮🇳 Malayalam input, 🇹🇭 Thai Kedmanee variants with complex composition, 🇺🇸 US International, 🇬🇧 United Kingdom Extended, 🇨🇦 Canadian Multilingual Standard, 🇨🇦 French Canadian, 🇪🇸 Spanish International, 🇵🇹 Portuguese ABNT, 🇧🇷 Portuguese ABNT2, 🇨🇿 Czech Programmers, 🇸🇰 Slovak Programmers, 🇭🇺 Hungarian 101-key, 🇵🇱 Polish Programmer.

<a id="installation"></a>

## 📦 التثبيت

إذا كان الملحق متاحًا في متجر ملحقات Flow Launcher، فثبّته من إعدادات الملحقات في Flow Launcher.

<a id="manual-installation"></a>

### التثبيت اليدوي

اكتب هذا في Flow Launcher:

```text
pm install https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases/latest/download/LayoutFallback.zip
```

بعد ذلك أعد تشغيل Flow Launcher بكتابة `Restart Flow Launcher` واختيار أمر النظام.

<a id="build"></a>
## 🛠 البناء

يتطلب .NET 9 SDK:

```powershell
winget install Microsoft.DotNet.SDK.9
```

ابنِ الإضافة:

```powershell
Set-ExecutionPolicy -Scope Process Bypass
.\build.ps1
```

سيتم إنشاء ملف ZIP القابل للتثبيت هنا:

```text
artifacts\LayoutFallback-0.1.4.zip
```

ثبّت ملف ZIP الناتج من إعدادات إضافات Flow Launcher، ثم أعد تشغيل Flow Launcher.

### تطوير محلي سريع

يمكنك استخدام سكربت يبني الإضافة وينسخ build إلى Flow Launcher، لذلك لا تحتاج إلى فعل ذلك يدويًا.

لمجلد إضافات Flow Launcher الافتراضي:

```powershell
.\install-dev.ps1
```

لنسخة Flow Launcher المحمولة أو مجلد إضافات مخصص:

```powershell
.\install-dev.ps1 -FlowPluginsDirectory "D:\Apps\FlowLauncher\UserData\Plugins"
```

تحتاج إلى إعادة تشغيل Flow Launcher بعد التثبيت.

## 📄 الترخيص

MIT — المساهمات مرحب بها.
