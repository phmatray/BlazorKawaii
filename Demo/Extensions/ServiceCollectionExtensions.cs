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
        
        return services;
    }
}