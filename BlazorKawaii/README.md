# BlazorKawaii

A collection of cute, customizable SVG components for Blazor WebAssembly applications.

## Features

- 🎨 12 kawaii components (Backpack, Browser, Cat, Chocolate, CreditCard, File, Folder, Ghost, IceCream, Mug, Planet, SpeechBubble)
- 😊 7 different moods (Blissful, Excited, Happy, Ko, Lovestruck, Sad, Shocked)
- 🎯 Fully customizable (size, color, mood)
- 🚀 Lightweight SVG-based components
- 📦 Easy to integrate

## Installation

```bash
dotnet add package BlazorKawaii
```

## Quick Start

1. Add the namespace to your `_Imports.razor`:

```razor
@using BlazorKawaii.Components.Cat
@using BlazorKawaii.Common
```

2. Use a component in your Razor page:

```razor
<Cat Mood="Mood.Happy" Size="200" Color="#FFD882" />
```

## Component Properties

All components share these properties:

- `Size` (int): The size of the component in pixels
- `Mood` (Mood): The facial expression (Blissful, Excited, Happy, Ko, Lovestruck, Sad, Shocked)
- `Color` (string): The primary color in hex format
- `ClassName` (string?): Optional CSS class name

## Examples

### Loading State
```razor
@if (isLoading)
{
    <Ghost Mood="Mood.Excited" Size="150" />
    <p>Loading your data...</p>
}
```

### Error State
```razor
@if (hasError)
{
    <Browser Mood="Mood.Ko" Size="200" Color="#FF6B6B" />
    <h3>Oops! Something went wrong</h3>
}
```

### Empty State
```razor
@if (!items.Any())
{
    <Folder Mood="Mood.Sad" Size="150" />
    <p>No files found</p>
}
```

## License

MIT License

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## Credits

Created with ❤️ by [phmatray](https://github.com/phmatray)