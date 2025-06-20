# 🌸 BlazorKawaii

A collection of cute, customizable SVG components for Blazor WebAssembly applications. Inspired by [react-kawaii](https://react-kawaii.vercel.app/), BlazorKawaii brings adorable, expressive components to the .NET ecosystem.

![Blazor Kawaii Demo](https://img.shields.io/badge/blazor-kawaii-ff69b4?style=for-the-badge)
![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=.net)
![License](https://img.shields.io/badge/license-MIT-green?style=for-the-badge)
[![NuGet](https://img.shields.io/nuget/v/BlazorKawaii.svg?style=for-the-badge)](https://www.nuget.org/packages/BlazorKawaii/)

## ✨ Features

- 🎨 **12 Kawaii Components**: Backpack, Browser, Cat, Chocolate, Credit Card, File, Folder, Ghost, Ice Cream, Mug, Planet, and Speech Bubble
- 😊 **7 Mood Expressions**: Sad, Shocked, Happy, Blissful, Lovestruck, Excited, and Ko
- 🎯 **Fully Customizable**: Size, color, and mood parameters for each component
- 🚀 **Blazor WebAssembly**: Built specifically for Blazor WASM applications
- 📱 **Responsive**: SVG-based components that scale perfectly
- 🧩 **Easy Integration**: Simple component-based architecture
- 🌍 **Internationalization**: Built-in support for English and French
- 🌓 **Dark Mode Support**: Components adapt beautifully to light and dark themes
- 📦 **NuGet Package**: Available as a reusable Razor Class Library

## 🚀 Getting Started

### Prerequisites

- .NET 9.0 SDK or later
- Visual Studio 2022, Visual Studio Code, or JetBrains Rider

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
[Parameter] public string? ClassName { get; set; } // Optional CSS class
```

#### Component List

| Component | Default Size | Default Color |
|-----------|--------------|---------------|
| Backpack | 240 | #FFD882 |
| Browser | 180 | #FDA7DC |
| Cat | 320 | #596881 |
| Chocolate | 300 | #FC105C |
| CreditCard | 240 | #FFD882 |
| File | 200 | #83D1FB |
| Folder | 200 | #FFD882 |
| Ghost | 240 | #E0E4E8 |
| IceCream | 300 | #FCCB7E |
| Mug | 200 | #A6E191 |
| Planet | 190 | #FCCB7E |
| SpeechBubble | 170 | #83D1FB |

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

<style>
    .kawaii-container {
        display: flex;
        gap: 2rem;
        padding: 2rem;
    }
    
    .custom-ghost {
        filter: drop-shadow(0 4px 8px rgba(0,0,0,0.1));
        transition: transform 0.2s ease;
    }
    
    .custom-ghost:hover {
        transform: translateY(-4px);
    }
</style>

<div class="kawaii-container">
    @foreach (var mood in Enum.GetValues<Mood>())
    {
        <div>
            <Ghost 
                Mood="@mood" 
                Size="150" 
                Color="@GetColorForMood(mood)" 
                ClassName="custom-ghost" />
            <p>@mood</p>
        </div>
    }
</div>

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
    [Parameter] public string Color { get; set; } = "#FFD882";
    [Parameter] public string? ClassName { get; set; }
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

- Inspired by [react-kawaii](https://react-kawaii.vercel.app/)
- Built with [Blazor WebAssembly](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
- SVG optimization and design patterns

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