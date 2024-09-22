using BlazorApp1;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

// Setup HttpClient for API calls
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]) });

// Configure OAuth 2.0 via OIDC
builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Local", options.ProviderOptions);  // Bind OAuth config from appsettings.json

    options.ProviderOptions.DefaultScopes.Add("offline");
    options.ProviderOptions.DefaultScopes.Add("public_profile");
    options.ProviderOptions.DefaultScopes.Add("write_account_data");
});

await builder.Build().RunAsync();