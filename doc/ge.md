🇺🇦 [Українська](ua.md) | 🇷🇺 [Русский](ru.md) | 🇧🇾 [Беларуская](by.md) | 🇧🇬 [Български](bg.md) | 🇷🇸 [Српски](rs.md) | 🇲🇰 [Македонски](mk.md) | 🇰🇿 [Қазақша](kz.md) | 🇰🇬 [Кыргызча](kg.md) | 🇲🇳 [Монгол](mn.md) | 🇬🇷 [Ελληνικά](gr.md) | 🇮🇱 [עברית](il.md) | 🇸🇦 [العربية](sa.md) | 🇮🇷 [فارسی](ir.md) | 🇦🇲 [Հայերեն](am.md) | 🇹🇭 [ไทย](th.md)

[![Flow Launcher](https://img.shields.io/badge/Flow%20Launcher-plugin-5c2d91?logo=windows&logoColor=white)](https://www.flowlauncher.com/)
[![Windows](https://img.shields.io/badge/Windows-10%2F11-0078D6?logo=windows&logoColor=white)](https://www.microsoft.com/windows)
[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Latest release](https://img.shields.io/github/v/release/LanKing/flow-launcher-plugin-layout-fallback?label=release)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![Downloads](https://img.shields.io/github/downloads/LanKing/flow-launcher-plugin-layout-fallback/total?label=downloads)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](../LICENSE)

> როდესაც Flow Launcher დავაყენე, გულწრფელად გამიკვირდა, რომ მსგავსი plugin ვერ ვიპოვე. ამან დამაფიქრა, რამდენი ადამიანის დრო დაიხარჯა არასწორი კლავიატურის განლაგებით შეყვანილი ტექსტის თავიდან აკრეფაზე, წაშლასა და გასწორებაზე.

# ⌨️ ამატებს fallback შედეგებს არასწორი კლავიატურის განლაგებებისთვის.

![⌨️](/doc/demo.png)

მაგალითები:
* `parametrebi` -> დამატებით ეძებს `პარამეტრები`
* `ჰელლო` -> დამატებით ეძებს `hello`

Plugin ამოწმებს მხოლოდ იმ კლავიატურის განლაგებებს, რომლებიც დაყენებულია მომხმარებლის Windows სისტემაში.

Flow Launcher-ის ორიგინალი შედეგები უცვლელი რჩება და ზემოთ ჩანს. Fallback შედეგები აღინიშნება `⌨` ნიშნით და იღებს score-ის ძლიერ შემცირებას.

<a id="how-it-works"></a>
## 🤓 მექანიკა დეტალურად

1. კითხულობს Windows-ში დაყენებულ კლავიატურის განლაგებებს `GetKeyboardLayoutList`, `HKCU\Keyboard Layout\Preload` და `HKCU\Keyboard Layout\Substitutes`.
2. ქმნის კონვერტაციის რუკებს ხელმისაწვდომი განლაგებების თითოეულ დალაგებულ წყვილს შორის.
3. ქმნის გასწორებულ ძიების კანდიდატებს და აშორებს სუსტ ან დუბლირებულ გარდაქმნებს.
4. გასწორებული კანდიდატებით კითხავს Flow Launcher-ის სხვა გლობალურ plugin-ებს.
5. ამატებს უფრო დაბალი პრიორიტეტის fallback შედეგებს Flow Launcher-ის საწყისი შედეგების შეცვლის გარეშე.

action keyword-ის მქონე პირდაპირი მოთხოვნები იგნორირებულია, ამიტომ plugin მონაწილეობს მხოლოდ ჩვეულებრივ გლობალურ ძიებაში.

<a id="notes"></a>
### 📓 შენიშვნები

* Fallback გამოყვანა შეზღუდულია 20 შედეგით და 6 შედეგით თითოეულ წყარო plugin-ზე.
* ზოგი მესამე მხარის plugin შეიძლება სხვაგვარად იქცეოდეს არაპირდაპირ მოთხოვნებზე, ამიტომ fallback შედეგები წყაროზეა დამოკიდებული.
* Layout Fallback არ თარგმნის და არ ტრანსლიტერირებს ტექსტს. ის მხოლოდ იმავე ფიზიკურ კლავიშის დაჭერებს განმარტავს სხვა დაყენებული Windows განლაგებებით.

<a id="supported-keyboard-layouts"></a>
## 🌍 მხარდაჭერილი კლავიატურის განლაგებები

Layout Fallback საუკეთესოდ მუშაობს პირდაპირ კლავიატურის განლაგებებთან, სადაც ერთი და იგივე ფიზიკური ღილაკები სხვადასხვა სიმბოლოს იძლევა.

საუკეთესო კანდიდატებია 🇺🇸 English US, 🇬🇧 English UK, 🇷🇺 Russian, 🇺🇦 Ukrainian, 🇧🇾 Belarusian, 🇧🇬 Bulgarian, 🇷🇸 Serbian Cyrillic, 🇲🇰 Macedonian, 🇰🇿 Kazakh, 🇰🇬 Kyrgyz, 🇲🇳 Mongolian Cyrillic, 🇬🇷 Greek, 🇮🇱 Hebrew, 🇸🇦 Arabic, 🇮🇷 Persian, 🇦🇲 Armenian, 🇬🇪 Georgian, 🇹🇭 Thai, 🇵🇱 Polish 214, 🇵🇱 Polish Typewriter.

ლათინურ ანბანზე დაფუძნებული განლაგებებიც შეიძლება მუშაობდეს, მაგრამ სარგებელი ჩვეულებრივ ნაკლებია, რადგან ბევრი სიმბოლო ინგლისურს ემთხვევა. ეს მოიცავს: 🇩🇪 German, 🇫🇷 French AZERTY, 🇪🇸 Spanish, 🇮🇹 Italian, 🇵🇹 Portuguese, 🇹🇷 Turkish Q, 🇨🇿 Czech QWERTY, 🇸🇰 Slovak QWERTY, 🇭🇺 Hungarian, 🇷🇴 Romanian, 🇱🇹 Lithuanian, 🇱🇻 Latvian, 🇪🇪 Estonian, 🇭🇷 Croatian, 🇸🇮 Slovenian, 🇦🇱 Albanian, 🇧🇦 Bosnian Latin, 🇷🇸 Serbian Latin, 🇳🇱 Dutch, 🇩🇰 Danish, 🇳🇴 Norwegian, 🇸🇪 Swedish, 🇫🇮 Finnish, 🇮🇸 Icelandic.

ზოგ განლაგებას შეიძლება ჰქონდეს შეზღუდული მხარდაჭერა, რადგან იყენებს IME-ს, dead keys-ს, რთულ კომპოზიციას, AltGr-ის ინტენსიურ გამოყენებას ან კანდიდატების არჩევას. ეს მოიცავს: 🇨🇳 Chinese Simplified IME, 🇹🇼 Chinese Traditional IME, 🇯🇵 Japanese IME, 🇰🇷 Korean IME, 🇻🇳 Vietnamese Telex, 🇻🇳 Vietnamese VNI, 🇮🇳 Hindi Devanagari input, 🇧🇩 Bengali input, 🇮🇳 Tamil input, 🇮🇳 Telugu input, 🇮🇳 Kannada input, 🇮🇳 Malayalam input, 🇹🇭 Thai Kedmanee variants with complex composition, 🇺🇸 US International, 🇬🇧 United Kingdom Extended, 🇨🇦 Canadian Multilingual Standard, 🇨🇦 French Canadian, 🇪🇸 Spanish International, 🇵🇹 Portuguese ABNT, 🇧🇷 Portuguese ABNT2, 🇨🇿 Czech Programmers, 🇸🇰 Slovak Programmers, 🇭🇺 Hungarian 101-key, 🇵🇱 Polish Programmer.

<a id="build"></a>
## 🛠 აწყობა

საჭიროა .NET 9 SDK:

```powershell
winget install Microsoft.DotNet.SDK.9
```

ააწყვეთ plugin:

```powershell
Set-ExecutionPolicy -Scope Process Bypass
.\build.ps1
```

დასაყენებელი ZIP შეიქმნება აქ:

```text
artifacts\LayoutFallback-0.1.4.zip
```

დააყენეთ გენერირებული ZIP Flow Launcher-ის plugin settings-იდან, შემდეგ თავიდან გაუშვით Flow Launcher.

### სწრაფი ლოკალური განვითარება

შეგიძლიათ გამოიყენოთ script, რომელიც აწყობს plugin-ს და build-ს აკოპირებს Flow Launcher-ში, რომ ეს ხელით არ გააკეთოთ.

Flow Launcher-ის plugins-ის ნაგულისხმევი საქაღალდისთვის:

```powershell
.\install-dev.ps1
```

Portable Flow Launcher-ისთვის ან custom plugins საქაღალდისთვის:

```powershell
.\install-dev.ps1 -FlowPluginsDirectory "D:\Apps\FlowLauncher\UserData\Plugins"
```

დაყენების შემდეგ საჭიროა Flow Launcher-ის თავიდან გაშვება.

## 📄 ლიცენზია

MIT — კონტრიბუციები მისასალმებელია.
