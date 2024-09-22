using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorApp1.Services
{

    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IAccessTokenProvider _tokenProvider;
        private readonly NavigationManager _navigationManager;

        public ApiService(HttpClient httpClient, IAccessTokenProvider tokenProvider, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _tokenProvider = tokenProvider;
            _navigationManager = navigationManager;
        }

        public async Task FetchAvatarData()
        {
            // Request access token
            var tokenResult = await _tokenProvider.RequestAccessToken();
            if (tokenResult.TryGetToken(out var token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Value);

                // Make API request to /data/avatars
                var avatarData = await _httpClient.GetFromJsonAsync<JsonElement>("data/avatars");

                // Dump the API data into a JSON file
                var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(avatarData, options);

                await File.WriteAllTextAsync("avatarData.json", json);
            }
            else
            {
                throw new AccessTokenNotAvailableException(_navigationManager, tokenResult, null);
            }
        }
    }
}