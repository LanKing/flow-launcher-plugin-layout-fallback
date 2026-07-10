🇺🇦 [Українська](ua.md) | 🇷🇺 [Русский](ru.md) | 🇧🇾 [Беларуская](by.md) | 🇧🇬 [Български](bg.md) | 🇷🇸 [Српски](rs.md) | 🇲🇰 [Македонски](mk.md) | 🇰🇿 [Қазақша](kz.md) | 🇰🇬 [Кыргызча](kg.md) | 🇲🇳 [Монгол](mn.md) | 🇮🇱 [עברית](il.md) | 🇸🇦 [العربية](sa.md) | 🇮🇷 [فارسی](ir.md) | 🇦🇲 [Հայերեն](am.md) | 🇬🇪 [ქართული](ge.md) | 🇹🇭 [ไทย](th.md)

[![Flow Launcher](https://img.shields.io/badge/Flow%20Launcher-plugin-5c2d91?logo=windows&logoColor=white)](https://www.flowlauncher.com/)
[![Windows](https://img.shields.io/badge/Windows-10%2F11-0078D6?logo=windows&logoColor=white)](https://www.microsoft.com/windows)
[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Latest release](https://img.shields.io/github/v/release/LanKing/flow-launcher-plugin-layout-fallback?label=release)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![Downloads](https://img.shields.io/github/downloads/LanKing/flow-launcher-plugin-layout-fallback/total?label=downloads)](https://github.com/LanKing/flow-launcher-plugin-layout-fallback/releases)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](../LICENSE)

> Όταν εγκατέστησα το Flow Launcher, πραγματικά εξεπλάγην που δεν μπόρεσα να βρω ένα τέτοιο plugin. Με έκανε να σκεφτώ πόσος ανθρώπινος χρόνος έχει χαθεί σε επαναπληκτρολόγηση, διαγραφή και διόρθωση κειμένου που γράφτηκε με λάθος διάταξη πληκτρολογίου.

# ⌨️ Προσθέτει fallback αποτελέσματα για λάθος διατάξεις πληκτρολογίου.

![⌨️](/doc/demo.png)

Παραδείγματα:
* `Ryumίseiw` -> αναζητά επίσης `Ρυθμίσεις`
* `ηελλο` -> αναζητά επίσης `hello`

Το plugin ελέγχει μόνο τις διατάξεις πληκτρολογίου που είναι εγκατεστημένες στο Windows σύστημα του χρήστη.

Τα αρχικά αποτελέσματα του Flow Launcher δεν αλλάζουν και παραμένουν ψηλότερα. Τα fallback αποτελέσματα σημειώνονται με `⌨` και λαμβάνουν ισχυρή ποινή score.

<a id="how-it-works"></a>
## 🤓 Η μηχανική με λεπτομέρειες

1. Διαβάζει τις εγκατεστημένες διατάξεις πληκτρολογίου των Windows με `GetKeyboardLayoutList`, `HKCU\Keyboard Layout\Preload` και `HKCU\Keyboard Layout\Substitutes`.
2. Δημιουργεί χάρτες μετατροπής ανάμεσα σε κάθε διατεταγμένο ζεύγος διαθέσιμων διατάξεων.
3. Παράγει διορθωμένους υποψήφιους όρους αναζήτησης και αφαιρεί αδύναμες ή διπλές μετατροπές.
4. Ρωτά τα άλλα καθολικά πρόσθετα του Flow Launcher με τους διορθωμένους υποψηφίους.
5. Προσθέτει fallback αποτελέσματα χαμηλότερης προτεραιότητας χωρίς να αγγίζει τα αρχικά αποτελέσματα του Flow Launcher.

Τα ρητά ερωτήματα με action keyword αγνοούνται, οπότε το πρόσθετο συμμετέχει μόνο στη συνηθισμένη καθολική αναζήτηση.

<a id="notes"></a>
### 📓 Σημειώσεις

* Η fallback έξοδος περιορίζεται σε 20 αποτελέσματα και 6 αποτελέσματα ανά πηγαίο πρόσθετο.
* Ορισμένα πρόσθετα τρίτων μπορεί να συμπεριφέρονται διαφορετικά όταν ερωτώνται έμμεσα, οπότε τα fallback αποτελέσματα μπορεί να διαφέρουν ανά πηγή.
* Το Layout Fallback δεν μεταφράζει ούτε μεταγράφει κείμενο. Απλώς επανερμηνεύει τα ίδια φυσικά πατήματα πλήκτρων μέσω άλλων εγκατεστημένων διατάξεων Windows.

<a id="supported-keyboard-layouts"></a>
## 🌍 Υποστηριζόμενες διατάξεις πληκτρολογίου

Το Layout Fallback λειτουργεί καλύτερα με άμεσες διατάξεις πληκτρολογίου, όπου τα ίδια φυσικά πλήκτρα παράγουν διαφορετικούς χαρακτήρες.

Οι καλύτεροι υποψήφιοι είναι 🇺🇸 English US, 🇬🇧 English UK, 🇷🇺 Russian, 🇺🇦 Ukrainian, 🇧🇾 Belarusian, 🇧🇬 Bulgarian, 🇷🇸 Serbian Cyrillic, 🇲🇰 Macedonian, 🇰🇿 Kazakh, 🇰🇬 Kyrgyz, 🇲🇳 Mongolian Cyrillic, 🇬🇷 Greek, 🇮🇱 Hebrew, 🇸🇦 Arabic, 🇮🇷 Persian, 🇦🇲 Armenian, 🇬🇪 Georgian, 🇹🇭 Thai, 🇵🇱 Polish 214, 🇵🇱 Polish Typewriter.

Οι λατινικές διατάξεις μπορούν επίσης να λειτουργήσουν, αλλά το όφελος είναι συνήθως μικρότερο, επειδή πολλοί χαρακτήρες συμπίπτουν με τα αγγλικά. Αυτό περιλαμβάνει: 🇩🇪 German, 🇫🇷 French AZERTY, 🇪🇸 Spanish, 🇮🇹 Italian, 🇵🇹 Portuguese, 🇹🇷 Turkish Q, 🇨🇿 Czech QWERTY, 🇸🇰 Slovak QWERTY, 🇭🇺 Hungarian, 🇷🇴 Romanian, 🇱🇹 Lithuanian, 🇱🇻 Latvian, 🇪🇪 Estonian, 🇭🇷 Croatian, 🇸🇮 Slovenian, 🇦🇱 Albanian, 🇧🇦 Bosnian Latin, 🇷🇸 Serbian Latin, 🇳🇱 Dutch, 🇩🇰 Danish, 🇳🇴 Norwegian, 🇸🇪 Swedish, 🇫🇮 Finnish, 🇮🇸 Icelandic.

Ορισμένες διατάξεις μπορεί να έχουν περιορισμένη υποστήριξη, επειδή βασίζονται σε IME, νεκρά πλήκτρα, σύνθετη σύνθεση, έντονη χρήση AltGr ή επιλογή υποψηφίων. Αυτό περιλαμβάνει: 🇨🇳 Chinese Simplified IME, 🇹🇼 Chinese Traditional IME, 🇯🇵 Japanese IME, 🇰🇷 Korean IME, 🇻🇳 Vietnamese Telex, 🇻🇳 Vietnamese VNI, 🇮🇳 Hindi Devanagari input, 🇧🇩 Bengali input, 🇮🇳 Tamil input, 🇮🇳 Telugu input, 🇮🇳 Kannada input, 🇮🇳 Malayalam input, 🇹🇭 Thai Kedmanee variants with complex composition, 🇺🇸 US International, 🇬🇧 United Kingdom Extended, 🇨🇦 Canadian Multilingual Standard, 🇨🇦 French Canadian, 🇪🇸 Spanish International, 🇵🇹 Portuguese ABNT, 🇧🇷 Portuguese ABNT2, 🇨🇿 Czech Programmers, 🇸🇰 Slovak Programmers, 🇭🇺 Hungarian 101-key, 🇵🇱 Polish Programmer.

<a id="build"></a>
## 🛠 Δημιουργία

Απαιτείται .NET 9 SDK:

```powershell
winget install Microsoft.DotNet.SDK.9
```

Δημιουργήστε το plugin:

```powershell
Set-ExecutionPolicy -Scope Process Bypass
.\build.ps1
```

Το εγκαταστάσιμο ZIP θα δημιουργηθεί εδώ:

```text
artifactsayoutfallback.zip
```

Εγκαταστήστε το παραγόμενο ZIP από τις ρυθμίσεις plugin του Flow Launcher και μετά επανεκκινήστε το Flow Launcher.

### Γρήγορη τοπική ανάπτυξη

Μπορείτε να χρησιμοποιήσετε ένα script που δημιουργεί το plugin και αντιγράφει το build στο Flow Launcher, ώστε να μην το κάνετε χειροκίνητα.

Για τον προεπιλεγμένο φάκελο plugin του Flow Launcher:

```powershell
.\install-dev.ps1
```

Για portable Flow Launcher ή προσαρμοσμένο φάκελο plugin:

```powershell
.\install-dev.ps1 -FlowPluginsDirectory "D:\Apps\FlowLauncher\UserData\Plugins"
```

Μετά την εγκατάσταση πρέπει να επανεκκινήσετε το Flow Launcher.

## 📄 Άδεια

MIT — οι συνεισφορές είναι ευπρόσδεκτες.
