# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

BlazorKawaii is a Blazor WebAssembly component library that provides cute, animated SVG components with customizable moods. The project targets .NET 9.0 and demonstrates component composition patterns in Blazor.

## Development Commands

```bash
# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run in development mode (https://localhost:7195)
dotnet run --project Demo/Demo.csproj

# Watch for changes during development
dotnet watch run --project Demo/Demo.csproj

# Publish for production
dotnet publish -c Release
```

## Architecture & Component Pattern

### Component Structure
Each kawaii component follows this consistent structure:
- `Components/[Name]/[Name].razor` - Razor markup with SVG
- `Components/[Name]/[Name].cs` - Partial class with parameters and logic
- `Components/[Name]/[Name]Paths.cs` - Static class containing SVG path constants

### Standard Component Parameters
```csharp
[Parameter] public int Size { get; set; } = [default];
[Parameter] public Mood Mood { get; set; } = Mood.Blissful;
[Parameter] public string Color { get; set; } = "[hex_color]";
[Parameter] public string? ClassName { get; set; }
```

### Component Composition Pattern
```razor
<Wrapper ClassName="@ClassName">
  <svg width="@(Size * ratio)" height="@Size" viewBox="...">
    <!-- Component-specific shapes -->
    <Face Mood="@Mood" Transform="translate(...)" UniqueId="@GetUniqueId()"/>
  </svg>
</Wrapper>
```

### Key Shared Components
- **Face**: Reusable component that renders different expressions based on Mood enum (Sad, Shocked, Happy, Blissful, Lovestruck, Excited, Ko)
- **Wrapper**: Container component providing consistent positioning and optional styling
- **SvgMaskHelper**: Utility for generating unique IDs to prevent SVG mask conflicts

### Adding New Components
1. Create folder under `Components/[ComponentName]/`
2. Add `[ComponentName].razor` with SVG following the wrapper pattern
3. Add `[ComponentName].cs` partial class with standard parameters
4. Add `[ComponentName]Paths.cs` if complex SVG paths are needed
5. Ensure Face component is positioned appropriately with Transform parameter

## Code Quality Tools

- **GitHub Actions**: Automated code quality checks on PRs and pushes
- **Renovate**: Automated dependency updates

## Important Notes

- No test project exists currently - consider adding tests when implementing new features
- All SVG components should maintain consistent shadow opacity (0.1-0.14)
- Use `SvgMaskHelper.GetUniqueId()` for any SVG masks to prevent rendering conflicts
- Components use partial classes - keep logic in .cs files, markup in .razor files