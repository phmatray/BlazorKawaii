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

All components inherit from `KawaiiComponentBase` which provides:
- Common parameters: `Size`, `Mood`, `Color`, `Class`, `Style`, `SvgClass`, `SvgStyle`
- Unique ID generation for SVG masks to prevent conflicts
- Abstract methods for face positioning and scaling

Each component consists of:
1. **Component.razor** - SVG markup using the Wrapper component
2. **Component.razor.cs** - Partial class inheriting from KawaiiComponentBase
3. **ComponentPaths.cs** - Static class containing SVG path data

### Key Design Patterns

1. **SVG Mask Isolation**: Each component instance gets a unique ID to prevent SVG mask conflicts when multiple components are on the same page.

2. **Culture-Invariant Formatting**: All numeric values in SVG attributes use `CultureInfo.InvariantCulture` to prevent decimal separator issues in different locales.

3. **Face Positioning**: Each component implements `GetFaceScale()` and `GetFacePosition()` to properly position the Face component based on React Kawaii's Figma measurements.

4. **Wrapper Pattern**: All components use the `<Wrapper>` component for consistent sizing and positioning.

### Localization

The demo app supports multiple languages (EN, FR, ES, NL) with:
- Resource files in `Demo/Resources/`
- `LanguageService` for URL-based language persistence
- Culture configuration in `WebAssemblyHostExtensions`

### CI/CD Pipeline

The GitHub Actions workflow (`ci-cd.yml`) handles:
- Multi-OS builds (Ubuntu, Windows, macOS)
- Automatic versioning using conventional commits
- NuGet package validation and publishing
- GitHub Pages deployment
- Deterministic builds for reproducible packages

### Important Configuration

1. **Central Package Management**: Uses `Directory.Packages.props` for consistent package versions
2. **Deterministic Builds**: Configured in `Directory.Build.props` for reproducible builds
3. **Symbol Generation**: Includes .snupkg files for debugging support
4. **XML Documentation**: Generated for IntelliSense support

### Common Issues & Solutions

1. **DOM Manipulation Errors**: The demo uses Prism.js for syntax highlighting. To prevent conflicts with Blazor's DOM updates, code highlighting is wrapped in try-catch blocks and only runs on first render.

2. **SVG Rendering Issues**: Always use `SvgFormatHelper.FormatSvgNumber()` for numeric SVG attributes to ensure culture-invariant formatting.

3. **Generic Type Inference**: MudBlazor components like `MudList` require explicit type parameters (e.g., `T="string"`).

### NuGet Publishing

To publish to NuGet.org:
1. Create an API key at https://www.nuget.org/account/apikeys
2. Add it as `NUGET_API_KEY` in GitHub repository secrets
3. The CI/CD pipeline will automatically publish on new version tags