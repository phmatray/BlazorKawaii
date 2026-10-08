namespace BlazorKawaii.Components;

/// <summary>
/// Provides SVG path data for the Padlock component.
/// </summary>
public static class PadlockPaths
{
    /// <summary>
    /// Gets the SVG path data for the Padlock body.
    /// </summary>
    public const string Body = @"
        <path fill=""#D3D9E0"" d=""M87 116V80a36 36 0 0 1 72 0v36h-17V80a19 19 0 0 0-38 0v36Z"" />
        <path fill=""#000"" opacity=""0.12"" d=""M87 116V80a36 36 0 0 1 72 0v36h-17V80a19 19 0 0 0-38 0v36Z"" />
        <path fill=""#D3D9E0"" transform=""translate(-6 0)"" d=""M87 116V80a36 36 0 0 1 72 0v36h-17V80a19 19 0 0 0-38 0v36Z"" />
        <rect fill=""currentColor"" x=""60"" y=""106"" width=""120"" height=""94"" rx=""24"" />
        <rect fill=""#000"" opacity=""0.1"" x=""60"" y=""106"" width=""120"" height=""94"" rx=""24"" />
        <rect fill=""currentColor"" x=""60"" y=""106"" width=""110"" height=""94"" rx=""24"" />";
}
