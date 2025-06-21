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

    public string GetUrlWithLanguage(string url)
    {
        var currentLang = CurrentLanguage;

        // If it's a relative URL, make it absolute
        if (!url.StartsWith("http"))
        {
            url = _navigationManager.ToAbsoluteUri(url).ToString();
        }

        var uri = new Uri(url);
        var queryParams = QueryHelpers.ParseQuery(uri.Query);

        // Add or update the lang parameter
        queryParams["lang"] = currentLang;

        // Rebuild the URL
        var queryDict = queryParams.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value.ToString()
        );
        var newQueryString = QueryHelpers.AddQueryString(uri.GetLeftPart(UriPartial.Path), queryDict!);

        // For relative navigation, return just the path and query
        if (!url.StartsWith("http"))
        {
            var baseUri = new Uri(_navigationManager.BaseUri);
            return newQueryString.Replace(baseUri.GetLeftPart(UriPartial.Authority), "");
        }

        return newQueryString;
    }

    public void NavigateWithLanguage(string uri, bool forceLoad = false)
    {
        var urlWithLang = GetUrlWithLanguage(uri);
        _navigationManager.NavigateTo(urlWithLang, forceLoad);
    }
}
