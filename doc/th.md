🇺🇦 [Українська](ua.md) | 🇷🇺 [Русский](ru.md) | 🇧🇾 [Беларуская](by.md) | 🇧🇬 [Български](bg.md) | 🇷🇸 [Српски](rs.md) | 🇲🇰 [Македонски](mk.md) | 🇰🇿 [Қазақша](kz.md) | 🇰🇬 [Кыргызча](kg.md) | 🇲🇳 [Монгол](mn.md) | 🇬🇷 [Ελληνικά](gr.md) | 🇮🇱 [עברית](il.md) | 🇸🇦 [العربية](sa.md) | 🇮🇷 [فارسی](ir.md) | 🇦🇲 [Հայերեն](am.md) | 🇬🇪 [ქართული](ge.md)

[![Flow Launcher](https://img.shields.io/badge/Flow%20Launcher-plugin-5c2d91?logo=windows&logoColor=white)](https://www.flowlauncher.com/)
[![Windows](https://img.shields.io/badge/Windows-10%2F11-0078D6?logo=windows&logoColor=white)](https://www.microsoft.com/windows)
[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Latest release](https://img.shields.io/github/v/release/LanKing/flow-launcher-plugin-layout-fallback?label=release)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![Downloads](https://img.shields.io/github/downloads/LanKing/flow-launcher-plugin-layout-fallback/total?label=downloads)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](../LICENSE)

> เมื่อผมติดตั้ง Flow Launcher ผมแปลกใจจริง ๆ ที่หา plugin แบบนี้ไม่เจอ มันทำให้ผมคิดว่ามนุษย์เสียเวลาไปเท่าไรกับการพิมพ์ใหม่ ลบ และแก้ข้อความที่พิมพ์ด้วย layout แป้นพิมพ์ผิด

# ⌨️ เพิ่มผลลัพธ์ fallback สำหรับ layout แป้นพิมพ์ที่ผิด.

![⌨️](/doc/demo.png)

ตัวอย่าง:
* `dki9yh'8jk` -> ค้นหาเพิ่ม `การตั้งค่า`
* `้ำสสน` -> ค้นหาเพิ่ม `hello`

plugin จะตรวจเฉพาะ layout แป้นพิมพ์ที่ติดตั้งอยู่ในระบบ Windows ของผู้ใช้เท่านั้น.

ผลลัพธ์เดิมของ Flow Launcher จะไม่ถูกแก้ไขและยังคงอยู่ด้านบน ผลลัพธ์ fallback จะถูกทำเครื่องหมายด้วย `⌨` และได้รับการลด score อย่างมาก

<a id="how-it-works"></a>
## 🤓 กลไกโดยละเอียด

1. อ่านผังแป้นพิมพ์ Windows ที่ติดตั้งไว้ด้วย `GetKeyboardLayoutList`, `HKCU\Keyboard Layout\Preload` และ `HKCU\Keyboard Layout\Substitutes`.
2. สร้างแผนที่การแปลงระหว่างคู่แบบมีลำดับของรูปแบบแป้นพิมพ์ที่มีอยู่ทั้งหมด
3. สร้างตัวเลือกคำค้นที่แก้ไขแล้ว และตัดการแปลงที่อ่อนหรือซ้ำออก
4. ส่งคำค้นไปยังปลั๊กอินแบบ global อื่นของ Flow Launcher ด้วยตัวเลือกที่แก้ไขแล้ว
5. เพิ่มผลลัพธ์ fallback ที่มีลำดับต่ำกว่าโดยไม่แตะผลลัพธ์เดิมของ Flow Launcher

คำค้นที่มี action keyword แบบชัดเจนจะถูกละเว้น ดังนั้นปลั๊กอินจะทำงานเฉพาะในการค้นหา global ปกติ

<a id="notes"></a>
### 📓 หมายเหตุ

* ผลลัพธ์ fallback จำกัดที่ 20 รายการ และ 6 รายการต่อปลั๊กอินต้นทาง
* ปลั๊กอินบุคคลที่สามบางตัวอาจทำงานต่างกันเมื่อถูกเรียกทางอ้อม ดังนั้นผลลัพธ์ fallback อาจขึ้นอยู่กับแหล่งที่มา
* Layout Fallback ไม่แปลภาษาและไม่ถอดเสียงข้อความ มันเพียงตีความการกดปุ่มจริงเดิมผ่านผังแป้นพิมพ์ Windows อื่นที่ติดตั้งไว้

<a id="supported-keyboard-layouts"></a>
## 🌍 layout แป้นพิมพ์ที่รองรับ

Layout Fallback ทำงานได้ดีที่สุดกับผังแป้นพิมพ์แบบตรง ที่ปุ่มจริงเดียวกันให้ตัวอักษรต่างกัน

ตัวเลือกที่เหมาะที่สุดคือ 🇺🇸 English US, 🇬🇧 English UK, 🇷🇺 Russian, 🇺🇦 Ukrainian, 🇧🇾 Belarusian, 🇧🇬 Bulgarian, 🇷🇸 Serbian Cyrillic, 🇲🇰 Macedonian, 🇰🇿 Kazakh, 🇰🇬 Kyrgyz, 🇲🇳 Mongolian Cyrillic, 🇬🇷 Greek, 🇮🇱 Hebrew, 🇸🇦 Arabic, 🇮🇷 Persian, 🇦🇲 Armenian, 🇬🇪 Georgian, 🇹🇭 Thai, 🇵🇱 Polish 214, 🇵🇱 Polish Typewriter.

รูปแบบที่ใช้ตัวอักษรละตินก็อาจทำงานได้เช่นกัน แต่ประโยชน์มักน้อยกว่า เพราะอักขระจำนวนมากซ้ำกับภาษาอังกฤษ ซึ่งรวมถึง: 🇩🇪 German, 🇫🇷 French AZERTY, 🇪🇸 Spanish, 🇮🇹 Italian, 🇵🇹 Portuguese, 🇹🇷 Turkish Q, 🇨🇿 Czech QWERTY, 🇸🇰 Slovak QWERTY, 🇭🇺 Hungarian, 🇷🇴 Romanian, 🇱🇹 Lithuanian, 🇱🇻 Latvian, 🇪🇪 Estonian, 🇭🇷 Croatian, 🇸🇮 Slovenian, 🇦🇱 Albanian, 🇧🇦 Bosnian Latin, 🇷🇸 Serbian Latin, 🇳🇱 Dutch, 🇩🇰 Danish, 🇳🇴 Norwegian, 🇸🇪 Swedish, 🇫🇮 Finnish, 🇮🇸 Icelandic.

บางรูปแบบอาจรองรับได้จำกัด เพราะพึ่งพา IME, dead keys, การประกอบอักขระที่ซับซ้อน, การใช้ AltGr มาก หรือการเลือก candidate ซึ่งรวมถึง: 🇨🇳 Chinese Simplified IME, 🇹🇼 Chinese Traditional IME, 🇯🇵 Japanese IME, 🇰🇷 Korean IME, 🇻🇳 Vietnamese Telex, 🇻🇳 Vietnamese VNI, 🇮🇳 Hindi Devanagari input, 🇧🇩 Bengali input, 🇮🇳 Tamil input, 🇮🇳 Telugu input, 🇮🇳 Kannada input, 🇮🇳 Malayalam input, 🇹🇭 Thai Kedmanee variants with complex composition, 🇺🇸 US International, 🇬🇧 United Kingdom Extended, 🇨🇦 Canadian Multilingual Standard, 🇨🇦 French Canadian, 🇪🇸 Spanish International, 🇵🇹 Portuguese ABNT, 🇧🇷 Portuguese ABNT2, 🇨🇿 Czech Programmers, 🇸🇰 Slovak Programmers, 🇭🇺 Hungarian 101-key, 🇵🇱 Polish Programmer.

<a id="build"></a>
## 🛠 Build

ต้องใช้ .NET 9 SDK:

```powershell
winget install Microsoft.DotNet.SDK.9
```

Build ปลั๊กอิน:

```powershell
Set-ExecutionPolicy -Scope Process Bypass
.\build.ps1
```

ZIP สำหรับติดตั้งจะถูกสร้างที่:

```text
artifacts\LayoutFallback-0.1.4.zip
```

ติดตั้ง ZIP ที่สร้างจาก plugin settings ของ Flow Launcher แล้วรีสตาร์ต Flow Launcher.

### การพัฒนา local แบบเร็ว

คุณสามารถใช้ script ที่ build ปลั๊กอินและคัดลอก build เข้า Flow Launcher ได้ จึงไม่ต้องทำเองด้วยมือ.

สำหรับโฟลเดอร์ plugins เริ่มต้นของ Flow Launcher:

```powershell
.\install-dev.ps1
```

สำหรับ Flow Launcher แบบ portable หรือโฟลเดอร์ plugins แบบกำหนดเอง:

```powershell
.\install-dev.ps1 -FlowPluginsDirectory "D:\Apps\FlowLauncher\UserData\Plugins"
```

หลังติดตั้งต้องรีสตาร์ต Flow Launcher.

## 📄 ใบอนุญาต

MIT — ยินดีรับการมีส่วนร่วม.
