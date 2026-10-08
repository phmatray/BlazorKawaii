namespace BlazorKawaii.Components;

/// <summary>
/// Provides SVG path data for the Gamepad component.
/// </summary>
public static class GamepadPaths
{
    /// <summary>
    /// Gets the SVG path data for the Gamepad body, d-pad and buttons.
    /// </summary>
    public const string Body = @"
        <path fill=""#000"" opacity=""0.1"" transform=""translate(0 7)"" d=""M70 62H170C205 62 215 92 222 142C228 182 215 197 195 197C175 197 168 177 155 167H85C72 177 65 197 45 197C25 197 12 182 18 142C25 92 35 62 70 62Z"" />
        <path fill=""currentColor"" d=""M70 62H170C205 62 215 92 222 142C228 182 215 197 195 197C175 197 168 177 155 167H85C72 177 65 197 45 197C25 197 12 182 18 142C25 92 35 62 70 62Z"" />
        <path fill=""#000"" opacity=""0.22"" d=""M50 96h12a3 3 0 0 1 3 3v9h9a3 3 0 0 1 3 3v12a3 3 0 0 1-3 3h-9v9a3 3 0 0 1-3 3H50a3 3 0 0 1-3-3v-9h-9a3 3 0 0 1-3-3v-12a3 3 0 0 1 3-3h9v-9a3 3 0 0 1 3-3Z"" />
        <circle fill=""#000"" opacity=""0.15"" cx=""184"" cy=""97"" r=""10.5"" />
        <circle fill=""#FF8EAD"" cx=""184"" cy=""97"" r=""8"" />
        <circle fill=""#FFF"" opacity=""0.45"" cx=""181.5"" cy=""94.5"" r=""2.5"" />
        <circle fill=""#000"" opacity=""0.15"" cx=""168"" cy=""114"" r=""10.5"" />
        <circle fill=""#83D1FB"" cx=""168"" cy=""114"" r=""8"" />
        <circle fill=""#FFF"" opacity=""0.45"" cx=""165.5"" cy=""111.5"" r=""2.5"" />
        <circle fill=""#000"" opacity=""0.15"" cx=""200"" cy=""114"" r=""10.5"" />
        <circle fill=""#A6E191"" cx=""200"" cy=""114"" r=""8"" />
        <circle fill=""#FFF"" opacity=""0.45"" cx=""197.5"" cy=""111.5"" r=""2.5"" />
        <circle fill=""#000"" opacity=""0.15"" cx=""184"" cy=""131"" r=""10.5"" />
        <circle fill=""#FFD882"" cx=""184"" cy=""131"" r=""8"" />
        <circle fill=""#FFF"" opacity=""0.45"" cx=""181.5"" cy=""128.5"" r=""2.5"" />";
}
