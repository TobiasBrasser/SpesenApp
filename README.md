# SpesenApp – ASP.NET Core Web-App

Eine einfache Installationsanleitung für eine Webanwendung zur Erfassung und Anzeige von Spesen, entwickelt mit ASP.NET Core MVC, EF Core und SQLite.

---

## Voraussetzungen

- [.NET SDK 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/de/) **oder**
- [Visual Studio Code](https://code.visualstudio.com/) + C#- & Razor-Erweiterung

---

## Setup & Ausführung

### Option 1: Visual Studio (empfohlen für Windows)

1. Projekt mit `.sln`-Datei öffnen (`SpesenApp.sln`)
2. Menü **Extras → NuGet-Paket-Manager → Paket-Manager-Konsole** öffnen
3. Migrationen anwenden:
   ```powershell
   Add-Migration InitialCreate
   Update-Database
4. Projekt starten (F5 oder Play Button)
5. Anwendung im Browser aufrufen: http://localhost:5233/

### Option 2: Visual Studio Code (plattformübegreifend)

1. Projekt-Ordner in Visual Studio Code öffnen
2. Terminal öffnen:
   ```bash
   git clone https://github.com/TobiasBrasser/SpesenApp.git
   cd SpesenApp
3. Datenbank erstellen:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
4. Anwendung starten: 
   ```bash
   dotnet run