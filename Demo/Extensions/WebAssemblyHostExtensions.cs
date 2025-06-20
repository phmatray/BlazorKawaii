using System.Globalization;
using Microsoft.JSInterop;

namespace Demo.Extensions;

public static class WebAssemblyHostExtensions
{
    private static readonly string[] SupportedCultures = { "en", "fr", "es", "nl" };
    
    public static async Task ConfigureCultureAsync(this Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHost host)
    {
        var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
        
        // Try to get culture from localStorage
        var culture = await GetStoredCultureAsync(jsInterop);
        
        // Validate and set default if needed
        culture = ValidateCulture(culture);
        
        // Apply the culture
        SetCulture(culture);
    }
    
    private static async Task<string> GetStoredCultureAsync(IJSRuntime jsInterop)
    {
        try
        {
            return await jsInterop.InvokeAsync<string?>("localStorage.getItem", "culture") ?? "en";
        }
        catch
        {
            return "en";
        }
    }
    
    private static string ValidateCulture(string culture)
    {
        return SupportedCultures.Contains(culture) ? culture : "en";
    }
    
    private static void SetCulture(string culture)
    {
        var cultureInfo = new CultureInfo(culture);
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
    }
}