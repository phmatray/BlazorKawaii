using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System.Globalization;

namespace Demo.Services;

public class LanguageService
{
    private readonly NavigationManager _navigationManager;

    public LanguageService(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }

    public string CurrentLanguage => CultureInfo.CurrentUICulture.Name;

    /// <summary>
    /// Returns <paramref name="url"/> with the current language in its <c>lang</c> query parameter.
    /// Relative URLs must not start with "/": they resolve against the app's base href, which is
    /// /BlazorKawaii/ on GitHub Pages.
    /// </summary>
    public string GetUrlWithLanguage(string url)
    {
        var uri = _navigationManager.ToAbsoluteUri(url);
        var queryParams = QueryHelpers.ParseQuery(uri.Query)
            .ToDictionary(kvp => kvp.Key, kvp => (string?)kvp.Value.ToString());
        queryParams["lang"] = CurrentLanguage;

        return QueryHelpers.AddQueryString(uri.GetLeftPart(UriPartial.Path), queryParams);
    }
}
