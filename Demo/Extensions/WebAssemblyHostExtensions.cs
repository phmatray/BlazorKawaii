using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.JSInterop;

namespace Demo.Extensions;

public static class WebAssemblyHostExtensions
{
    private static readonly string[] SupportedCultures = { "en", "fr", "es", "nl" };
    
    public static async Task ConfigureCultureAsync(this Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHost host)
    {
        var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
        var navigationManager = host.Services.GetRequiredService<NavigationManager>();
        
        // Try to get culture from URL first
        var culture = GetCultureFromUrl(navigationManager.Uri);
        
        // If not in URL, try localStorage
        if (string.IsNullOrEmpty(culture))
        {
            culture = await GetStoredCultureAsync(jsInterop);
        }
        else
        {
            // If found in URL, also save to localStorage for consistency
            await jsInterop.InvokeVoidAsync("localStorage.setItem", "culture", culture);
        }
        
        // Validate and set default if needed
        culture = ValidateCulture(culture);
        
        // Apply the culture
        SetCulture(culture);
    }
    
    private static string? GetCultureFromUrl(string uri)
    {
        try
        {
            var queryString = new Uri(uri).Query;
            var queryParams = QueryHelpers.ParseQuery(queryString);
            
            if (queryParams.TryGetValue("lang", out var langValue))
            {
                return langValue.ToString();
            }
        }
        catch
        {
            // Ignore parsing errors
        }
        
        return null;
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