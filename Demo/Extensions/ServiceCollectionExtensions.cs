using Demo.Services;
using MudBlazor.Services;

namespace Demo.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBlazorKawaiiServices(this IServiceCollection services)
    {
        // Add MudBlazor services
        services.AddMudServices();
        
        // Add localization services
        services.AddLocalization();
        
        // Add language service
        services.AddScoped<LanguageService>();
        
        // Add NuGet version service
        services.AddScoped<INuGetVersionService, NuGetVersionService>();
        
        return services;
    }
}