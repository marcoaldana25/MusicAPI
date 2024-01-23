using MusicAPI.Accessors.Interfaces;
using System.Net.Http.Headers;

namespace MusicAPI.Accessors
{
    public class SpotifyAccessor : ISpotifyAccessor
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private const string BaseUri = "https://api.spotify.com/v1";
        public SpotifyAccessor(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task GetCurrentUserProfileAsync(string bearerToken)
        {
            var httpClient = _httpClientFactory.CreateClient();

            httpClient
                .DefaultRequestHeaders
                .Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

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
            }
        }
    }
}
