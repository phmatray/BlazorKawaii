# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

BlazorKawaii is a Blazor WebAssembly component library that provides cute, customizable SVG components. It's a port of the React Kawaii library to the .NET ecosystem, featuring 22 kawaii components with 7 different mood expressions.

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

### Face animation check
```bash
# With the demo running: measures how far each animated face's eyes, mouth and cheeks move on screen
# (VISIBLE / SUBTLE / NONE per mood, exit 1 on NONE), and writes a frame-by-frame sheet
node tools/face-motion.mjs "http://localhost:5000/documentation#animation" --out ./artifacts/face-motion
# Every face must stay still when the system asks for reduced motion
node tools/face-motion.mjs "http://localhost:5000/documentation#animation" --reduced-motion
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
1. **Component.razor** - SVG markup using the Wrapper component; its `<Face … />` must pass `Animated="@Animated"`
2. **Component.razor.cs** - Partial class inheriting from KawaiiComponentBase
3. **ComponentPaths.cs** - Static class containing SVG path data

### Key Design Patterns

1. **SVG Mask Isolation**: Each component instance gets a unique ID to prevent SVG mask conflicts when multiple components are on the same page.

2. **Culture-Invariant Formatting**: All numeric values in SVG attributes use `CultureInfo.InvariantCulture` to prevent decimal separator issues in different locales.

3. **Face Positioning**: Each component implements `GetFaceScale()` and `GetFacePosition()` to properly position the Face component based on React Kawaii's Figma measurements.

4. **Wrapper Pattern**: All components use the `<Wrapper>` component for consistent sizing and positioning.

### Demo Mascot Catalog

`Demo/Shared/KawaiiCatalog.cs` is the single list of mascots used by the gallery, the playground and the documentation (rendered through `DynamicComponent`). A new mascot needs an entry there plus a `[Name]Desc` key in the four `.resx` files.

Demo links must never start with `/`: the site is served under `/BlazorKawaii/` on GitHub Pages, and `LanguageService.GetUrlWithLanguage` resolves relative URLs against the base href.

### Localization

The demo app supports multiple languages (EN, FR, ES, NL) with:
- Resource files in `Demo/Resources/`
- `LanguageService` for URL-based language persistence
- Culture configuration in `WebAssemblyHostExtensions`

### CI/CD Pipeline

- `ci-cd.yml` builds on Ubuntu, Windows and macOS and runs CodeQL, on pushes to `dev` and on PRs.
- `release-please.yml` runs on `dev` (the default branch; `main` is no longer used for releases). It reads the
  Conventional Commits, keeps a release PR up to date (CHANGELOG.md, `.release-please-manifest.json`, `<Version>`
  in `BlazorKawaii.csproj`), and when that PR is merged it tags `vX.Y.Z`, creates the GitHub Release, publishes
  the NuGet package and deploys the demo to GitHub Pages.
- Commit messages and PR titles must follow Conventional Commits (`feat:`, `fix:`, …): they decide the version.

### Important Configuration

1. **Central Package Management**: Uses `Directory.Packages.props` for consistent package versions
2. **Deterministic Builds**: Configured in `Directory.Build.props` for reproducible builds
3. **Symbol Generation**: Includes .snupkg files for debugging support
4. **XML Documentation**: Generated for IntelliSense support

### Common Issues & Solutions

1. **Syntax Highlighting**: The demo's `CodeBlock` asks Prism.js (manual mode) for highlighted HTML through `PrismWrapper.highlight` and renders it itself, so Prism never edits Blazor-owned DOM and the code re-highlights when it changes.

2. **No `<use xlink:href>`**: Blazor sets `xlink:href` without the XLink namespace, so browsers ignore it. Draw shapes inline instead of referencing them.

3. **SVG Rendering Issues**: Always use `SvgFormatHelper.FormatSvgNumber()` for numeric SVG attributes to ensure culture-invariant formatting.

4. **Generic Type Inference**: MudBlazor components like `MudList` require explicit type parameters (e.g., `T="string"`).

### NuGet Publishing

Publishing uses [Trusted Publishing](https://learn.microsoft.com/nuget/nuget-org/trusted-publishing) —
no long-lived API key is stored anywhere. The workflow exchanges GitHub's OIDC token for a NuGet key
valid about an hour, used immediately.

To set it up:
1. On nuget.org, register a Trusted Publishing policy for the `BlazorKawaii` package, naming this
   repository and the workflow file `release-please.yml`
2. Add your nuget.org **profile name** as `NUGET_USER` in GitHub repository secrets — it is not a
   credential; the OIDC exchange is what authorizes the push
3. Merging the release PR opened by release-please publishes the package