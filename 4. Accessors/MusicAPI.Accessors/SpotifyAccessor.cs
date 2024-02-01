using MusicAPI.Accessors.DataTransferObjects;
using MusicAPI.Accessors.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace MusicAPI.Accessors
{
    public class SpotifyAccessor(IHttpClientFactory httpClientFactory) : ISpotifyAccessor
    {
        private const string BaseUri = "https://api.spotify.com/v1";

        public async Task<UserProfile> GetCurrentUserProfileAsync(string bearerToken)
        {
            if (string.IsNullOrWhiteSpace(bearerToken))
            {
                throw new ArgumentNullException(nameof(bearerToken));
            }

            var httpClient = SetupHttpClient(bearerToken);

            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                new Uri($"{BaseUri}/me"));

            var response = await httpClient
                .SendAsync(httpRequestMessage);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response
                    .Content
                    .ReadAsStringAsync();

                var userProfile = JsonSerializer
                    .Deserialize<UserProfile>(responseContent);

                return userProfile ?? new UserProfile();
            }

            throw new HttpRequestException($"Unable to retrieve user profile information from {BaseUri}");
        }

        public async Task<string> GetSearchAsync(string bearerToken, Search searchRequest)
        {
            if (string.IsNullOrWhiteSpace(bearerToken))
            {
                throw new ArgumentNullException(nameof(bearerToken));
            }

            var httpClient = SetupHttpClient(bearerToken);

            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                new Uri($"{BaseUri}/search?q={searchRequest.SearchQuery}&type={searchRequest.SearchType.ToLower()}&market=ES"));

            var response = await httpClient
                .SendAsync(httpRequestMessage);

            if (response.IsSuccessStatusCode)
            {
                return await response
                    .Content
                    .ReadAsStringAsync();
            }

            return string.Empty;
        }

        private HttpClient SetupHttpClient(string bearerToken)
        {
            var httpClient = httpClientFactory.CreateClient();

            httpClient
                .DefaultRequestHeaders
                .Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            return httpClient;
        }
    }
}
