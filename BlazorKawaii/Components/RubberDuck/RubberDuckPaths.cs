namespace BlazorKawaii.Components;

/// <summary>
/// Provides SVG path data for the RubberDuck component.
/// </summary>
public static class RubberDuckPaths
{
    /// <summary>
    /// Gets the SVG path data for the RubberDuck body.
    /// </summary>
    public const string Body = @"
        <g transform=""translate(0 6)"">
            <ellipse fill=""#F08A3A"" cx=""96"" cy=""194"" rx=""17"" ry=""8"" />
            <ellipse fill=""#F08A3A"" cx=""144"" cy=""194"" rx=""17"" ry=""8"" />
            <ellipse fill=""currentColor"" cx=""58"" cy=""150"" rx=""13"" ry=""24"" transform=""rotate(35 58 150)"" />
            <ellipse fill=""currentColor"" cx=""182"" cy=""150"" rx=""13"" ry=""24"" transform=""rotate(-35 182 150)"" />
            <ellipse fill=""#000"" opacity=""0.1"" cx=""182"" cy=""150"" rx=""13"" ry=""24"" transform=""rotate(-35 182 150)"" />
            <ellipse fill=""currentColor"" cx=""120"" cy=""156"" rx=""64"" ry=""38"" />
            <path fill=""#000"" opacity=""0.1"" d=""M115 118.12A64 38 0 1 1 115 193.88A64 38 0 0 0 115 118.12Z"" />
            <path fill=""currentColor"" d=""M118 44C112 34 114 24 124 20C121 28 125 36 128 42Z"" />
            <path fill=""currentColor"" d=""M70 90a50 50 0 1 0 100 0a50 50 0 1 0 -100 0Z"" />
            <path fill=""#000"" opacity=""0.1"" d=""M115.5 139.8A50 50 0 1 0 115.5 40.2A50 50 0 0 1 115.5 139.8Z"" />
        </g>";
}
