🇺🇦 [Українська](ua.md) | 🇷🇺 [Русский](ru.md) | 🇧🇾 [Беларуская](by.md) | 🇧🇬 [Български](bg.md) | 🇷🇸 [Српски](rs.md) | 🇲🇰 [Македонски](mk.md) | 🇰🇿 [Қазақша](kz.md) | 🇰🇬 [Кыргызча](kg.md) | 🇲🇳 [Монгол](mn.md) | 🇬🇷 [Ελληνικά](gr.md) | 🇮🇱 [עברית](il.md) | 🇸🇦 [العربية](sa.md) | 🇦🇲 [Հայերեն](am.md) | 🇬🇪 [ქართული](ge.md) | 🇹🇭 [ไทย](th.md)

[![Flow Launcher](https://img.shields.io/badge/Flow%20Launcher-plugin-5c2d91?logo=windows&logoColor=white)](https://www.flowlauncher.com/)
[![Windows](https://img.shields.io/badge/Windows-10%2F11-0078D6?logo=windows&logoColor=white)](https://www.microsoft.com/windows)
[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Latest release](https://img.shields.io/github/v/release/LanKing/flow-launcher-plugin-layout-fallback?label=release)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![Downloads](https://img.shields.io/github/downloads/LanKing/flow-launcher-plugin-layout-fallback/total?label=downloads)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](../LICENSE)

> وقتی Flow Launcher را نصب کردم، واقعاً تعجب کردم که افزونه‌ای مثل این پیدا نکردم. این باعث شد فکر کنم چه مقدار زمان انسانی برای دوباره تایپ کردن، حذف کردن و اصلاح متنی که با چیدمان اشتباه صفحه‌کلید وارد شده تلف شده است.

# ⌨️ نتایج fallback را برای چیدمان‌های اشتباه صفحه‌کلید اضافه می‌کند.

![⌨️](/doc/demo.png)

نمونه‌ها:
* `jkzdlhj` -> همچنین جستجو می‌کند `تنظیمات`
* `اثممخ` -> همچنین جستجو می‌کند `hello`

این افزونه فقط چیدمان‌های صفحه‌کلید نصب‌شده در سیستم Windows کاربر را بررسی می‌کند.

نتایج اصلی Flow Launcher بدون تغییر باقی می‌مانند و بالاتر نمایش داده می‌شوند. نتایج fallback با `⌨` علامت‌گذاری می‌شوند و کاهش شدید score می‌گیرند.

<a id="how-it-works"></a>
## 🤓 سازوکار با جزئیات

1. چیدمان‌های صفحه‌کلید نصب‌شدهٔ Windows را می‌خواند با `GetKeyboardLayoutList`, `HKCU\Keyboard Layout\Preload` و `HKCU\Keyboard Layout\Substitutes`.
2. میان هر جفت مرتب از چیدمان‌های موجود، نقشه‌های تبدیل می‌سازد.
3. گزینه‌های اصلاح‌شدهٔ جستجو را تولید می‌کند و تبدیل‌های ضعیف یا تکراری را حذف می‌کند.
4. افزونه‌های جهانی دیگر Flow Launcher را با گزینه‌های اصلاح‌شده پرس‌وجو می‌کند.
5. نتایج fallback با اولویت پایین‌تر را بدون دست زدن به نتایج اصلی Flow Launcher اضافه می‌کند.

پرس‌وجوهای صریح با action keyword نادیده گرفته می‌شوند، بنابراین افزونه فقط در جستجوی جهانی معمولی شرکت می‌کند.

<a id="notes"></a>
### 📓 یادداشت‌ها

* خروجی fallback به 20 نتیجه و 6 نتیجه برای هر افزونهٔ منبع محدود است.
* برخی افزونه‌های شخص ثالث ممکن است در پرس‌وجوی غیرمستقیم رفتار متفاوتی داشته باشند، بنابراین نتایج fallback می‌تواند به منبع وابسته باشد.
* Layout Fallback متن را ترجمه یا آوانویسی نمی‌کند. فقط همان فشارهای فیزیکی کلیدها را از طریق چیدمان‌های نصب‌شدهٔ دیگر Windows بازتفسیر می‌کند.

<a id="supported-keyboard-layouts"></a>
## 🌍 چیدمان‌های صفحه‌کلید پشتیبانی‌شده

Layout Fallback با چیدمان‌های مستقیم صفحه‌کلید بهتر کار می‌کند؛ جایی که همان کلیدهای فیزیکی نویسه‌های متفاوتی تولید می‌کنند.

بهترین گزینه‌ها عبارت‌اند از 🇺🇸 English US, 🇬🇧 English UK, 🇷🇺 Russian, 🇺🇦 Ukrainian, 🇧🇾 Belarusian, 🇧🇬 Bulgarian, 🇷🇸 Serbian Cyrillic, 🇲🇰 Macedonian, 🇰🇿 Kazakh, 🇰🇬 Kyrgyz, 🇲🇳 Mongolian Cyrillic, 🇬🇷 Greek, 🇮🇱 Hebrew, 🇸🇦 Arabic, 🇮🇷 Persian, 🇦🇲 Armenian, 🇬🇪 Georgian, 🇹🇭 Thai, 🇵🇱 Polish 214, 🇵🇱 Polish Typewriter.

چیدمان‌های مبتنی بر لاتین هم می‌توانند کار کنند، اما سود آن معمولاً کمتر است، چون بسیاری از نویسه‌ها با انگلیسی هم‌پوشانی دارند. شامل: 🇩🇪 German, 🇫🇷 French AZERTY, 🇪🇸 Spanish, 🇮🇹 Italian, 🇵🇹 Portuguese, 🇹🇷 Turkish Q, 🇨🇿 Czech QWERTY, 🇸🇰 Slovak QWERTY, 🇭🇺 Hungarian, 🇷🇴 Romanian, 🇱🇹 Lithuanian, 🇱🇻 Latvian, 🇪🇪 Estonian, 🇭🇷 Croatian, 🇸🇮 Slovenian, 🇦🇱 Albanian, 🇧🇦 Bosnian Latin, 🇷🇸 Serbian Latin, 🇳🇱 Dutch, 🇩🇰 Danish, 🇳🇴 Norwegian, 🇸🇪 Swedish, 🇫🇮 Finnish, 🇮🇸 Icelandic.

برخی چیدمان‌ها ممکن است پشتیبانی محدود داشته باشند، چون به IME، کلیدهای مرده، ترکیب پیچیده، استفاده زیاد از AltGr یا انتخاب کاندیدا وابسته‌اند. شامل: 🇨🇳 Chinese Simplified IME, 🇹🇼 Chinese Traditional IME, 🇯🇵 Japanese IME, 🇰🇷 Korean IME, 🇻🇳 Vietnamese Telex, 🇻🇳 Vietnamese VNI, 🇮🇳 Hindi Devanagari input, 🇧🇩 Bengali input, 🇮🇳 Tamil input, 🇮🇳 Telugu input, 🇮🇳 Kannada input, 🇮🇳 Malayalam input, 🇹🇭 Thai Kedmanee variants with complex composition, 🇺🇸 US International, 🇬🇧 United Kingdom Extended, 🇨🇦 Canadian Multilingual Standard, 🇨🇦 French Canadian, 🇪🇸 Spanish International, 🇵🇹 Portuguese ABNT, 🇧🇷 Portuguese ABNT2, 🇨🇿 Czech Programmers, 🇸🇰 Slovak Programmers, 🇭🇺 Hungarian 101-key, 🇵🇱 Polish Programmer.

<a id="build"></a>
## 🛠 ساخت

به .NET 9 SDK نیاز دارد:

```powershell
winget install Microsoft.DotNet.SDK.9
```

پلاگین را بسازید:

```powershell
Set-ExecutionPolicy -Scope Process Bypass
.\build.ps1
```

فایل ZIP قابل نصب در این مسیر ساخته می‌شود:

```text
artifacts\LayoutFallback-0.1.4.zip
```

فایل ZIP ساخته‌شده را از تنظیمات پلاگین‌های Flow Launcher نصب کنید، سپس Flow Launcher را دوباره اجرا کنید.

### توسعه محلی سریع

می‌توانید از اسکریپتی استفاده کنید که پلاگین را می‌سازد و build را داخل Flow Launcher کپی می‌کند، بنابراین لازم نیست این کار را دستی انجام دهید.

برای پوشه پیش‌فرض پلاگین‌های Flow Launcher:

```powershell
.\install-dev.ps1
```

برای Flow Launcher portable یا پوشه پلاگین دلخواه:

```powershell
.\install-dev.ps1 -FlowPluginsDirectory "D:\Apps\FlowLauncher\UserData\Plugins"
```

پس از نصب باید Flow Launcher را دوباره اجرا کنید.

## 📄 مجوز

MIT — مشارکت‌ها خوش‌آمدند.
