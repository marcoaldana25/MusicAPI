using Microsoft.Extensions.Caching.Memory;
using MusicAPI.Accessors.DataTransferObjects;
using MusicAPI.Accessors.Interfaces;
using MusicAPI.Utilities.Interfaces;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace MusicAPI.Accessors
{
    public class AuthorizationAccessor(
            IConfigurationManager configurationManager,
            IHttpClientFactory httpClientFactory,
            IMemoryCache memoryCache) : IAuthorizationAccessor
    {
        private const string TokenBaseUrl = "https://accounts.spotify.com/api/token";

        private const string SpotifyAccessTokenKey = "SpotifyAccessToken";


        public async Task<string> RequestAccessTokenAsync()
        {
            try
            {
                if (memoryCache.TryGetValue(SpotifyAccessTokenKey, out var accessToken))
                {
                    return accessToken?.ToString() ?? string.Empty;
                }

                var httpClient = CreateHttpClient();

                var httpRequestMessage = CreateRefreshAccessTokenRequestMessage();

                var response = await httpClient.SendAsync(httpRequestMessage);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response
                        .Content
                        .ReadAsStringAsync();

                    var spotifyAccessToken = JsonSerializer
                        .Deserialize<SpotifyAccessToken>(responseContent);

                    SetCache(
                        SpotifyAccessTokenKey,
                        spotifyAccessToken?.AccessToken ?? string.Empty,
                        spotifyAccessToken?.ExpiresIn);

                    return spotifyAccessToken?.AccessToken ?? string.Empty;
                }

                return string.Empty;

            }
            catch (Exception exception)
            {
                return exception.Message.ToString();
            }
        }

        private HttpClient CreateHttpClient()
        {
            var httpClient = httpClientFactory.CreateClient();

            var byteArray = new UTF8Encoding()
                .GetBytes($"{configurationManager.GetSpotifyClientId()}:{configurationManager.GetSpotifyClientSecret()}");

            httpClient
                .DefaultRequestHeaders
                .Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            return httpClient;
        }

        private HttpRequestMessage CreateRefreshAccessTokenRequestMessage()
        {
            var httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Post,
                    new Uri(TokenBaseUrl));

            var formData = new List<KeyValuePair<string, string>>
            {
                new("client_id", configurationManager.GetSpotifyClientId()),
                new("refresh_token", configurationManager.GetSpotifyAuthorizationCode()),
                new("grant_type", "refresh_token")
            };

            httpRequestMessage
                .Content = new FormUrlEncodedContent(formData);

            return httpRequestMessage;
        }

        private void SetCache(string key, string value, int? expirationInSeconds)
        {
            var memoryCacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(expirationInSeconds ?? 60));

            memoryCache
                .Set(key, value, memoryCacheEntryOptions);
        }
    }
}
