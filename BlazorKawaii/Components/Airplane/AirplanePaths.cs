namespace BlazorKawaii.Components;

/// <summary>
/// Provides SVG path data for the Airplane component.
/// </summary>
public static class AirplanePaths
{
    /// <summary>
    /// Gets the SVG path data for the Airplane body.
    /// </summary>
    public const string Body = @"
        <g transform=""translate(0 8)"">
            <path fill=""currentColor"" d=""M108 110L114 54C114.6 49 117 46 120 46C123 46 125.4 49 126 54L132 110Z"" />
            <path fill=""#000"" opacity=""0.1"" d=""M120 46C123 46 125.4 49 126 54L132 110H124L121.5 54C121.3 50 120.8 47 120 46Z"" />
            <path fill=""currentColor"" d=""M44 138C38 139 36 146 40 150L48 152H192L200 150C204 146 202 139 196 138L152 126H88Z"" />
            <path fill=""#000"" opacity=""0.1"" d=""M192 152L200 150C204 146 202 139 196 138L152 126H140L188 140C192 142 194 148 192 152Z"" />
            <circle fill=""currentColor"" cx=""72"" cy=""160"" r=""13"" />
            <circle fill=""currentColor"" cx=""168"" cy=""160"" r=""13"" />
            <path fill=""#000"" opacity=""0.1"" d=""M70 172.85A13 13 0 1 0 70 147.15A13 13 0 0 1 70 172.85Z"" />
            <path fill=""#000"" opacity=""0.1"" d=""M166 172.85A13 13 0 1 0 166 147.15A13 13 0 0 1 166 172.85Z"" />
            <circle fill=""#000"" opacity=""0.25"" cx=""72"" cy=""161"" r=""7"" />
            <circle fill=""#000"" opacity=""0.25"" cx=""168"" cy=""161"" r=""7"" />
            <path fill=""currentColor"" d=""M74 130a46 46 0 1 0 92 0a46 46 0 1 0 -92 0Z"" />
            <path fill=""#000"" opacity=""0.1"" d=""M115.5 175.78A46 46 0 1 0 115.5 84.22A46 46 0 0 1 115.5 175.78Z"" />
        </g>";
}
