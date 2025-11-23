# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

BlazorKawaii is a Blazor WebAssembly component library that provides cute, customizable SVG components. It's a port of the React Kawaii library to the .NET ecosystem, featuring 16 kawaii components with 7 different mood expressions.

## Build Commands

### Development
```bash
# Restore dependencies
dotnet restore

# Build the entire solution
dotnet build

# Build in Release mode
dotnet build --configuration Release

# Run the demo application
dotnet run --project Demo/Demo.csproj

# Watch mode for development
dotnet watch run --project Demo/Demo.csproj
```

### Testing & Validation
```bash
# Run tests (when available)
dotnet test

# Validate NuGet package
dotnet tool install -g Meziantou.Framework.NuGetPackageValidation.Tool
meziantou.validate-nuget-package ./artifacts/*.nupkg
```

### Publishing
```bash
# Pack the library for NuGet
dotnet pack BlazorKawaii/BlazorKawaii.csproj --configuration Release --output ./artifacts

# Publish demo for GitHub Pages
dotnet publish Demo/Demo.csproj --configuration Release --output ./dist -p:GHPages=true
```

## Architecture

### Solution Structure
- **BlazorKawaii/** - The main Razor Class Library (RCL) containing all kawaii components
- **Demo/** - Blazor WebAssembly demo application showcasing the components

### Component Architecture

All components inherit from `KawaiiComponentBase` (BlazorKawaii/Common/KawaiiComponentBase.cs) which provides:
- Common parameters: `Size`, `Mood`, `Color`, `Class`, `Style`, `SvgClass`, `SvgStyle`
- Unique ID generation for SVG masks to prevent conflicts
- Abstract methods `GetFaceScale()` and `GetFacePosition()` for face positioning

Each component consists of:
1. **Component.razor** - SVG markup using the Wrapper component
2. **Component.razor.cs** - Partial class inheriting from KawaiiComponentBase with face positioning logic
3. **ComponentPaths.cs** - Static class containing SVG path data as string constants

### Key Design Patterns

1. **SVG Mask Isolation**: Each component instance gets a unique ID via `SvgMaskHelper.GetUniqueId()` to prevent SVG mask conflicts when multiple components are on the same page.

2. **Culture-Invariant Formatting**: All numeric values in SVG attributes use `SvgFormatHelper.FormatSvgNumber()` which applies `CultureInfo.InvariantCulture` to prevent decimal separator issues in different locales (e.g., "1.5" vs "1,5").

3. **Face Positioning**: Each component implements `GetFaceScale()` and `GetFacePosition()` to properly position the Face component based on React Kawaii's Figma measurements. The scale is calculated as `figmaFaceWidth / 66.0` where 66 is the original face width.

4. **Wrapper Pattern**: All components use the `<Wrapper>` component (BlazorKawaii/Common/Wrapper/Wrapper.razor) for consistent sizing and positioning with relative positioning.

5. **Color Replacement**: SVG paths use "currentColor" as placeholder which is replaced at render time with the actual color via `.Replace("currentColor", Color ?? DefaultColor)`.

### Localization

The demo app supports multiple languages (EN, FR, ES, NL) with:
- Resource files in `Demo/Resources/` using standard .NET resource (.resx) files
- `LanguageService` (Demo/Services/LanguageService.cs) for URL-based language persistence via query parameters
- Culture configuration in `WebAssemblyHostExtensions` (Demo/Extensions/WebAssemblyHostExtensions.cs) which:
  - Reads culture from URL query parameter (`?lang=en`)
  - Falls back to localStorage if not in URL
  - Validates culture against supported cultures array
  - Redirects with valid culture in URL if needed
  - Synchronizes between URL and localStorage

### CI/CD Pipeline

The GitHub Actions workflow (`.github/workflows/ci-cd.yml`) handles:
- Multi-OS builds (Ubuntu, Windows, macOS) for validation
- Automatic versioning using conventional commits (via mathieudutour/github-tag-action)
- NuGet package validation using Meziantou.Framework.NuGetPackageValidation.Tool
- NuGet package publishing (requires `NUGET_API_KEY` secret)
- GitHub Pages deployment of demo
- Deterministic builds for reproducible packages
- CodeQL security analysis

Conventional commit rules:
- `breaking:` → major version bump
- `feat:` → minor version bump
- `fix:`, `perf:`, `revert:`, `refactor:`, `docs:` → patch version bump
- `test:`, `style:`, `chore:`, `ci:` → no version bump

### Important Configuration

1. **Central Package Management**: Uses `Directory.Packages.props` for consistent package versions across projects
2. **Deterministic Builds**: Configured in `Directory.Build.props` with `<Deterministic>true</Deterministic>` and `<ContinuousIntegrationBuild>` for reproducible builds
3. **Symbol Generation**: Uses embedded symbols (`<DebugType>embedded</DebugType>`) instead of separate .snupkg files
4. **XML Documentation**: Generated for IntelliSense support with `<GenerateDocumentationFile>true</GenerateDocumentationFile>`
5. **Target Framework**: Currently targets .NET 10.0 (`<TargetFramework>net10.0</TargetFramework>`)
6. **Nullability**: Enabled globally with `<Nullable>enable</Nullable>` and specific nullable warnings treated as errors

### Common Issues & Solutions

1. **DOM Manipulation Errors**: The demo uses Prism.js for syntax highlighting in `CodeBlock.razor`. To prevent conflicts with Blazor's DOM updates, code highlighting is wrapped in try-catch blocks and only runs on first render with a 100ms delay.

2. **SVG Rendering Issues**: Always use `SvgFormatHelper.FormatSvgNumber()` for numeric SVG attributes to ensure culture-invariant formatting. Never use direct `.ToString()` on doubles/floats in SVG context.

3. **Generic Type Inference**: MudBlazor components like `MudList` require explicit type parameters (e.g., `T="string"`).

4. **SVG Color Replacement**: When adding new components, ensure SVG paths use "currentColor" as the color placeholder, then replace it in the .razor file with the actual color using `@((MarkupString)ComponentPaths.Body.Replace("currentColor", Color ?? DefaultColor))`.

### Creating a New Component

When adding a new component, follow this structure:

1. Create folder: `BlazorKawaii/Components/[ComponentName]/`

2. Create `[ComponentName].razor.cs`:
```csharp
using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

public partial class NewComponent : KawaiiComponentBase
{
    protected override string DefaultColor => "#A6E191";

    protected override double GetFaceScale()
    {
        // Calculate: figmaFaceWidth / 66.0
        return 50.0 / 66.0;
    }

    protected override (double x, double y) GetFacePosition()
    {
        // Get coordinates from Figma measurements
        return (100.0, 100.0);
    }
}
```

3. Create `[ComponentName]Paths.cs`:
```csharp
namespace BlazorKawaii.Components;

public static class NewComponentPaths
{
    public const string Body = @"<path d=""..."" fill=""currentColor"" />";
}
```

4. Create `[ComponentName].razor`:
```razor
@namespace BlazorKawaii.Components
@inherits KawaiiComponentBase

<Wrapper Class="@Class" Style="@Style">
    <svg class="@SvgClass" style="@SvgStyle" xmlns="http://www.w3.org/2000/svg" width="@Size" height="@Size" viewBox="0 0 240 240" fill="none">
        @((MarkupString)NewComponentPaths.Body.Replace("currentColor", Color ?? DefaultColor))

        <Face Mood="@Mood" Scale="@GetFaceScale()" X="@GetFacePosition().x" Y="@GetFacePosition().y" />
    </svg>
</Wrapper>
```

5. Add to demo showcase in `Demo/Pages/Components/Components.razor`

### NuGet Publishing

To publish to NuGet.org:
1. Create an API key at https://www.nuget.org/account/apikeys
2. Add it as `NUGET_API_KEY` in GitHub repository secrets
3. The CI/CD pipeline will automatically publish on new version tags based on conventional commits
4. Version is automatically determined by commit messages (breaking/feat/fix/etc.)