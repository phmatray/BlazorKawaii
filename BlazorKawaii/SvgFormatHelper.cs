using System.Globalization;

namespace BlazorKawaii.Common;

public static class SvgFormatHelper
{
    /// <summary>
    /// Formats a number for SVG attributes using invariant culture to ensure decimal point separator
    /// </summary>
    public static string FormatSvgNumber(double value)
    {
        return value.ToString(CultureInfo.InvariantCulture);
    }
}