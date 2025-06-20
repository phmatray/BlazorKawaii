using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Demo;
using Demo.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Configure root components
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configure services
builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazorKawaiiServices();

// Build and configure host
var host = builder.Build();
await host.ConfigureCultureAsync();

// Run the application
await host.RunAsync();