namespace BlazorKawaii;

public static class SvgMaskHelper
{
    public static string GetUniqueId()
    {
        return Guid.NewGuid().ToString("N").Substring(0, 8);
    }
}