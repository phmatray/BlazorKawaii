using System.Text.Json;
using System.Text.Json.Serialization;

namespace Demo.Services;

/// <summary>
/// Service for fetching the latest version of the BlazorKawaii package from NuGet.org.
/// </summary>
public interface INuGetVersionService
{
    /// <summary>
    /// Gets the latest stable version of the BlazorKawaii package.
    /// </summary>
    /// <returns>The version string, or null when NuGet.org cannot be reached.</returns>
    Task<string?> GetLatestVersionAsync();
}

/// <summary>
/// Implementation of the NuGet version service.
/// </summary>
public class NuGetVersionService : INuGetVersionService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<NuGetVersionService> _logger;
    private string? _cachedVersion;
    private DateTime _cacheExpiry = DateTime.MinValue;
    private readonly TimeSpan _cacheTimeout = TimeSpan.FromHours(1);

    public NuGetVersionService(HttpClient httpClient, ILogger<NuGetVersionService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<string?> GetLatestVersionAsync()
    {
        // Return cached version if still valid
        if (!string.IsNullOrEmpty(_cachedVersion) && DateTime.UtcNow < _cacheExpiry)
        {
            return _cachedVersion;
        }

        try
        {
            // Query NuGet API for package metadata
            var response = await _httpClient.GetAsync("https://api.nuget.org/v3-flatcontainer/blazorkawaii/index.json");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var versionData = JsonSerializer.Deserialize<NuGetVersionResponse>(json);

                // Versions are listed oldest first; skip pre-releases such as 2.1.0-beta.1
                var latest = versionData?.Versions?.LastOrDefault(v => !v.Contains('-'));
                if (latest is not null)
                {
                    _cachedVersion = latest;
                    _cacheExpiry = DateTime.UtcNow.Add(_cacheTimeout);
                    return _cachedVersion;
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to fetch version from NuGet.org");
        }

        return null;
    }

    private class NuGetVersionResponse
    {
        [JsonPropertyName("versions")]
        public string[]? Versions { get; set; }
    }
}