namespace BlazorKawaii.Common;

/// <summary>
/// Provides helper methods for generating unique IDs for SVG masks to prevent conflicts.
/// </summary>
public static class SvgMaskHelper
{
    /// <summary>
    /// Generates a unique identifier suitable for use as an SVG element ID.
    /// </summary>
    /// <returns>An 8-character hexadecimal string that is guaranteed to be unique.</returns>
    /// <remarks>
    /// This method is used to ensure that multiple instances of the same component
    /// on a page have unique SVG mask IDs to prevent rendering conflicts.
    /// </remarks>
    public static string GetUniqueId()
    {
        return Guid.NewGuid().ToString("N").Substring(0, 8);
    }
}
