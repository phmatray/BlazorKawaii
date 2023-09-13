using System.Globalization;

namespace Demo;

public static class SvgMaskHelper
{
    public static string GetUniqueId()
    {
        var random = new Random();
        
        var id = Convert
            .ToString(random.NextDouble(), CultureInfo.InvariantCulture)
            .Substring(2, 15);

        return id;
    }
}