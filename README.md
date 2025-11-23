# 🌸 BlazorKawaii

![BlazorKawaii Logo](https://raw.githubusercontent.com/phmatray/BlazorKawaii/main/logo.png)

A collection of cute, customizable SVG components for Blazor WebAssembly applications.

Based on the wonderful [React Kawaii](https://react-kawaii.vercel.app/) library by [Miuki Miu](https://github.com/miukimiu), BlazorKawaii brings these adorable, expressive components to the .NET ecosystem.

![Blazor Kawaii Demo](https://img.shields.io/badge/blazor-kawaii-ff69b4?style=for-the-badge)
![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=.net)
![License](https://img.shields.io/badge/license-MIT-green?style=for-the-badge)
[![NuGet](https://img.shields.io/nuget/v/BlazorKawaii.svg?style=for-the-badge)](https://www.nuget.org/packages/BlazorKawaii/)

## ✨ Features

- 🎨 **16 Kawaii Components**: Astronaut, Backpack, Browser, Cat, Chocolate, Credit Card, Cyborg, File, Folder, Ghost, HumanCat, HumanDinosaur, Ice Cream, Mug, Planet, and Speech Bubble
- 😊 **7 Mood Expressions**: Sad, Shocked, Happy, Blissful, Lovestruck, Excited, and Ko
- 🎯 **Fully Customizable**: Size, color, and mood parameters for each component
- 🚀 **Blazor WebAssembly**: Built specifically for Blazor WASM applications
- 📱 **Responsive**: SVG-based components that scale perfectly
- 🧩 **Easy Integration**: Simple component-based architecture
- 🌍 **Internationalization**: Built-in support for English, French, Spanish, and Dutch
- 🌓 **Dark Mode Support**: Components adapt beautifully to light and dark themes
- 📦 **NuGet Package**: Available as a reusable Razor Class Library

## 🚀 Getting Started

### Prerequisites

- .NET 10.0 SDK or later
- Visual Studio 2026, Visual Studio Code, or JetBrains Rider

### Installation

#### Option 1: Install from NuGet (Recommended)

```bash
dotnet add package BlazorKawaii
```

#### Option 2: Clone and Run Demo

1. Clone the repository:
```bash
git clone https://github.com/phmatray/BlazorKawaii.git
cd BlazorKawaii
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Run the demo application:
```bash
dotnet run --project Demo/Demo.csproj
```

4. Open your browser and navigate to `https://localhost:7195`

## 📖 Usage

### Basic Usage

```razor
@using BlazorKawaii.Components
@using BlazorKawaii.Common

<Cat Mood="Mood.Blissful" Size="200" Color="#596881" />
```

### Available Components

All components share the same parameter structure:

```csharp
[Parameter] public int Size { get; set; }        // Component size in pixels
[Parameter] public Mood Mood { get; set; }       // Expression mood
[Parameter] public string Color { get; set; }    // Primary color (hex)
[Parameter] public string? Class { get; set; }     // CSS class for wrapper
[Parameter] public string? Style { get; set; }     // CSS style for wrapper
[Parameter] public string? SvgClass { get; set; }  // CSS class for SVG element
[Parameter] public string? SvgStyle { get; set; }  // CSS style for SVG element
```

#### Component List

| Component     | Default Size | Default Color |
|---------------|--------------|---------------|
| Astronaut     | 240          | #A6E191       |
| Backpack      | 240          | #A6E191       |
| Browser       | 180          | #A6E191       |
| Cat           | 320          | #A6E191       |
| Chocolate     | 300          | #A6E191       |
| CreditCard    | 240          | #A6E191       |
| Cyborg        | 240          | #A6E191       |
| File          | 200          | #A6E191       |
| Folder        | 200          | #A6E191       |
| Ghost         | 240          | #A6E191       |
| HumanCat      | 240          | #A6E191       |
| HumanDinosaur | 240          | #A6E191       |
| IceCream      | 300          | #A6E191       |
| Mug           | 200          | #A6E191       |
| Planet        | 190          | #A6E191       |
| SpeechBubble  | 170          | #A6E191       |

### Mood Expressions

```csharp
public enum Mood
{
    Sad,
    Shocked,
    Happy,
    Blissful,
    Lovestruck,
    Excited,
    Ko
}
```

### Advanced Example

```razor
@page "/custom-demo"
@using BlazorKawaii.Components
@using BlazorKawaii.Common

@* Style your components with CSS classes *@
@foreach (var mood in Enum.GetValues<Mood>())
{
    <Ghost 
        Mood="@mood" 
        Size="150" 
        Color="@GetColorForMood(mood)" 
        SvgClass="custom-ghost" />
}

@code {
    private string GetColorForMood(Mood mood) => mood switch
    {
        Mood.Sad => "#B0C4DE",
        Mood.Happy => "#98FB98",
        Mood.Lovestruck => "#FFB6C1",
        _ => "#E0E4E8"
    };
}
```

## 🏗️ Architecture

### Component Structure

Each kawaii component follows a consistent pattern:

```
Components/
└── ComponentName/
    ├── ComponentName.razor      # SVG markup
    ├── ComponentName.cs         # C# partial class with parameters
    └── ComponentNamePaths.cs    # SVG path constants
```

### Shared Components

- **Face**: Reusable component that renders different expressions based on mood
- **Wrapper**: Container component for consistent positioning
- **SvgMaskHelper**: Utility for generating unique IDs to prevent SVG conflicts

## 🛠️ Development

### Building the Project

```bash
dotnet build
```

### Running in Development Mode

```bash
dotnet watch run --project Demo/Demo.csproj
```

### Creating a New Component

1. Create a new folder under `Components/[ComponentName]/`
2. Add `[ComponentName].cs` with the standard parameters
3. Add `[ComponentName]Paths.cs` with SVG path constants
4. Add `[ComponentName].razor` following the wrapper pattern
5. Ensure the Face component is positioned appropriately

Example structure:
```csharp
// NewComponent.cs
public partial class NewComponent
{
    [Parameter] public int Size { get; set; } = 200;
    [Parameter] public Mood Mood { get; set; } = Mood.Blissful;
    [Parameter] public string Color { get; set; } = "#A6E191";
    [Parameter] public string? Class { get; set; }
    [Parameter] public string? Style { get; set; }
    [Parameter] public string? SvgClass { get; set; }
    [Parameter] public string? SvgStyle { get; set; }
}
```

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request. For major changes, please open an issue first to discuss what you would like to change.

### Guidelines

1. Follow the existing component structure
2. Ensure all components support the standard parameters
3. Maintain consistent SVG quality and style
4. Add your component to the demo page
5. Update documentation

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- **Original Project**: [React Kawaii](https://react-kawaii.vercel.app/) by [Miuki Miu](https://github.com/miukimiu)
  - This project is a faithful adaptation of React Kawaii for the Blazor ecosystem
  - All original SVG designs and moods are created by Miuki Miu
  - Licensed under MIT License
- Built with [Blazor WebAssembly](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
- Adapted for .NET by [Philippe Matray](https://github.com/phmatray)

## 🚀 GitHub Pages Deployment

This project is configured for easy deployment to GitHub Pages.

### Automatic Deployment

The project includes a GitHub Actions workflow that automatically deploys to GitHub Pages when you push to the main branch.

1. Enable GitHub Pages in your repository settings:
   - Go to Settings > Pages
   - Set Source to "Deploy from a branch"
   - Select "gh-pages" branch and "/ (root)" folder
   - Save the settings

2. Push your changes to the main branch:
```bash
git push origin main
```

3. The GitHub Action will automatically build and deploy your site to `https://[your-username].github.io/BlazorKawaii/`

### Manual Deployment

You can also deploy manually using the command line:

```bash
# Publish with GitHub Pages configuration
dotnet publish Demo/Demo.csproj -c:Release -p:GHPages=true

# The published files will be in publish/wwwroot
```

Or use the included publish profile:
```bash
dotnet publish Demo/Demo.csproj -p:PublishProfile=GitHubPages
```

## 📞 Support

- Create an issue for bug reports or feature requests
- Check out the [live demo](https://phmatray.github.io/BlazorKawaii/) for examples
- Refer to the CLAUDE.md file for AI-assisted development guidelines

---

Made with ❤️ and Blazor
