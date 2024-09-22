using BlazorApp1;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Fetch Base URL for API from appsettigs.json
var apiBaseAddress = builder.Configuration["ApiBaseUrl"];

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(apiBaseAddress)
});

// Configure OIDC Authenication
builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Local", options.ProviderOptions);

    // Log or inspect the value of Authority duing runtime
    Console.WriteLine($"Authority: {options.ProviderOptions.Authority}");
    options.ProviderOptions.DefaultScopes.Add("/data"); // Add the required API Scope for the tierd-party API
    options.ProviderOptions.Authority = builder.Configuration["Local:Authority"];
});

// Configure the API Authirzation Message Handler
builder.Services.AddScoped<AuthorizationMessageHandler>(sp =>
{
    var handler = sp.GetRequiredService<AuthorizationMessageHandler>()
                    .ConfigureHandler(
                        authorizedUrls: [apiBaseAddress],   // The Third-party API URL
                        scopes: ["/data"]                   // API Scope
                    );
    return handler;
});

// Use the API Authirzation Message Handler for httpClient
builder.Services.AddScoped(sp =>
    new HttpClient(sp.GetRequiredService<AuthorizationMessageHandler>())
    {
        BaseAddress = new Uri(apiBaseAddress)
    });

await builder.Build().RunAsync();