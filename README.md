# Dudepower Project Manager

A cross-platform project management tool for mid-to-large scale animation production — built to organize the entire production pipeline, from the design phase all the way to content publication.

More than just a project tracker, Dudepower Project Manager also helps you analyze statistical data about project progress and team performance by inspecting and computing data from every project.

## 🎯 Project Goals

- **Asset & Project Management** — Assist with managing project assets and creating projects
- **Performance Analytics** — Analyze and monitor animator performance while working
- **Fast, Integrated Workflow** — Build a quick and integrated working system

## 🖥️ Platform Support

Dudepower Project Manager supports **cross-platform** operation on both **Windows** and **macOS**. To enable this, the software is built with **C#** and uses **AvaloniaUI** for its multiplatform interface.

## ✨ Features

| Feature | Description |
|---------|-------------|
| **Home** | Main dashboard with multi-view support — toggle between list and card views, fully responsive to any window size |
| **Recent Projects** | Quick access to your most recent animation projects |
| **Work Statistics** | Analytics and performance insights across projects |
| **YouTube Studio** | Opens YouTube Studio in the system browser (testing) |
| **Notifications** | Stay up to date with project activity |
| **Settings** | Configure the application to your needs |
| **User Profile** | Manage your personal profile and preferences |

The side panel tabs switch with a smooth **slide left/right animation**, and the app follows your **system dark/light theme** — updating live when the theme changes while the app is running.

## 📁 Project Structure

The codebase is organized around a clean separation of UI, UI logic, and business logic:

```
<dpProject>
 ├── asset/                          <-- Master directory for assets
 ├────── ico/                        <-- All icons used across the UI
 ├────── media/                      <-- Animation and GIF assets
 ├────── app_20x20.icns/             <-- Master app icons
 ├────── app_20x20.ico/
 ├── bin/
 ├── int/                            <-- Mastermind UI layer
 ├────── element/                    <-- UI elements (axaml)
 ├───────── logical/                 <-- Code-behind for xaml UI
 ├──────────── method/               <-- Business logic (math, APIs, etc.)
 ├───────── rules/                   <-- UI style rules (colors, etc.)
 ├────── win/                        <-- Window UI (same structure as element)
 ├── obj/
 ├── App.axaml
 ├── App.axaml.cs
 ├── app.manifest
 ├── dpProject.csproj
 ├── init.axaml                      <-- Mastermind of the UI
 ├── init.cs
 └── Program.cs                      <-- Launcher
```

### Structuring Rules

- **UI code-behind lives in `logical/`** — every C# file containing code-behind for a XAML UI must sit inside a `logical` folder.
- **Business logic lives in `method/`** — every C# file containing logical methods (math calculations, API configuration, etc.) goes inside a `method` folder within the relevant `logical` subfolder.
- **Per-class folders** — each class (e.g., `dpProjectMan.Client`) has its own folder containing an `element` folder for UI elements, with the `axaml` linked to its code-behind in `logical/`, and logical functions linked to `logical/method/`.

## 🧩 Tech Stack

- **Language:** C#
- **UI Framework:** [AvaloniaUI](https://avaloniaui.net/) (multiplatform)
- **Target Platforms:** Windows, macOS
- **UI Design Reference:** [Figma Prototype](https://www.figma.com/make/IvfzXenXWcQF5l81HEPeD0/Project-Management-Desktop-UI?t=QDuVxj3PyGuCrlBH-1)

## 🚧 Status

> This project is under active development. The YouTube Studio shortcut currently opens in the system browser for testing.

## 📄 License

License information to be added.
