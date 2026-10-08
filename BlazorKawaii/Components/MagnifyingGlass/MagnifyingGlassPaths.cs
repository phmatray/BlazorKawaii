namespace BlazorKawaii.Components;

/// <summary>
/// Provides SVG path data for the MagnifyingGlass component.
/// </summary>
public static class MagnifyingGlassPaths
{
    /// <summary>
    /// Gets the SVG path data for the MagnifyingGlass body.
    /// </summary>
    public const string Body = @"
        <rect fill=""currentColor"" x=""162"" y=""94"" width=""20"" height=""20"" rx=""3"" transform=""rotate(45 106 104)"" />
        <rect fill=""#000"" opacity=""0.2"" x=""162"" y=""94"" width=""20"" height=""20"" rx=""3"" transform=""rotate(45 106 104)"" />
        <rect fill=""currentColor"" x=""176"" y=""90"" width=""50"" height=""28"" rx=""14"" transform=""rotate(45 106 104)"" />
        <rect fill=""#000"" opacity=""0.2"" x=""176"" y=""90"" width=""50"" height=""28"" rx=""14"" transform=""rotate(45 106 104)"" />
        <circle fill=""#fff"" cx=""106"" cy=""104"" r=""44"" />
        <circle fill=""currentColor"" opacity=""0.45"" cx=""106"" cy=""104"" r=""44"" />
        <path fill=""#fff"" opacity=""0.8"" d=""M74.05 92.37A34 34 0 0 1 93.26 72.48L95.51 78.04A28 28 0 0 0 79.69 94.42Z"" />
        <path fill=""currentColor"" fill-rule=""evenodd"" d=""M46 104a60 60 0 1 0 120 0a60 60 0 1 0 -120 0ZM62 104a44 44 0 1 0 88 0a44 44 0 1 0 -88 0Z"" />
        <path fill=""#000"" opacity=""0.1"" d=""M101.5 163.83A60 60 0 1 0 101.5 44.17A60 60 0 0 1 101.5 163.83Z"" />";
}
