using Microsoft.Extensions.Caching.Memory;
using MusicAPI.Accessors.DataTransferObjects;
using MusicAPI.Accessors.Interfaces;
using MusicAPI.Utilities.Interfaces;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace MusicAPI.Accessors
{
    public class AuthorizationAccessor : IAuthorizationAccessor
    {
        private const string TokenBaseUrl = "https://accounts.spotify.com/api/token";

        private readonly IConfigurationManager _configurationManager;

        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IMemoryCache _memoryCache;

        private const string SpotifyAccessTokenKey = "SpotifyAccessToken";

        public AuthorizationAccessor(
            IConfigurationManager configurationManager,
            IHttpClientFactory httpClientFactory,
            IMemoryCache memoryCache)
        {
            _configurationManager = configurationManager;
            _httpClientFactory = httpClientFactory;
            _memoryCache = memoryCache;
        }

        public async Task<string> RequestAccessTokenAsync()
        {
            try
            {
                if (_memoryCache.TryGetValue(SpotifyAccessTokenKey, out var accessToken))
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
            var httpClient = _httpClientFactory.CreateClient();

            var byteArray = new UTF8Encoding()
                .GetBytes($"{_configurationManager.GetSpotifyClientId()}:{_configurationManager.GetSpotifyClientSecret()}");

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
                    new KeyValuePair<string, string>("client_id", _configurationManager.GetSpotifyClientId()),
                    new KeyValuePair<string, string>("refresh_token", _configurationManager.GetSpotifyAuthorizationCode()),
                    new KeyValuePair<string, string>("grant_type", "refresh_token")
                };

            httpRequestMessage
                .Content = new FormUrlEncodedContent(formData);

            return httpRequestMessage;
        }

        private void SetCache(string key, string value, int? expirationInSeconds)
        {
            var memoryCacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(expirationInSeconds ?? 60));

            _memoryCache
                .Set(key, value, memoryCacheEntryOptions);
        }
    }
}
