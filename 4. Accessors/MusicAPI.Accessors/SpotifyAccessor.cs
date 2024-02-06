using MusicAPI.Accessors.DataTransferObjects;
using MusicAPI.Accessors.Interfaces;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MusicAPI.Accessors
{
    public class SpotifyAccessor(IHttpClientFactory httpClientFactory) : ISpotifyAccessor
    {
        public async Task<UserProfile> GetCurrentUserProfileAsync(string bearerToken, string queryString)
        {
            ValidateParameters(bearerToken, queryString);

            var response = await ExecuteGetRequest(bearerToken, queryString);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response
                    .Content
                    .ReadAsStringAsync();

                var userProfile = JsonSerializer
                    .Deserialize<UserProfile>(responseContent);

                return userProfile ?? new UserProfile();
            }

            throw new HttpRequestException($"Unable to retrieve user profile information from {queryString}");
        }

        public async Task<SearchResult> GetSearchAsync(string bearerToken, string queryString)
        {
            ValidateParameters(bearerToken, queryString);

            var response = await ExecuteGetRequest(bearerToken, queryString);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response
                    .Content
                    .ReadAsStringAsync();

                var searchResult = JsonSerializer
                    .Deserialize<SearchResult>(responseContent);

                return searchResult ?? new SearchResult();
            }

            throw new HttpRequestException($"Unable to retrieve Search Data using the request {queryString}");
        }

        public async Task<Artist> GetArtistAsync(string bearerToken, string queryString)
        {
            ValidateParameters(bearerToken, queryString);

            var response = await ExecuteGetRequest(bearerToken, queryString);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response
                    .Content
                    .ReadAsStringAsync();

                var artist = JsonSerializer
                    .Deserialize<Artist>(responseContent);

                return artist ?? new Artist();
            }

            throw new HttpRequestException($"Unable to retrieve Artist data using the request {queryString}");
        }

        public async Task<TopTracks> GetTopTracksAsync(string bearerToken, string queryString)
        {
            ValidateParameters(bearerToken, queryString);

            var response = await ExecuteGetRequest(bearerToken, queryString);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response
                    .Content
                    .ReadAsStringAsync();

                var topTracks =  JsonSerializer
                    .Deserialize<TopTracks>(responseContent);

                return topTracks ?? new TopTracks();
            }

            throw new HttpRequestException($"Unable to retrieve Artist Top Tracks using the request {queryString}");
        }

        public async Task<Albums> GetArtistAlbumsAsync(string bearerToken, string queryString)
        {
            ValidateParameters(bearerToken, queryString);

            var response = await ExecuteGetRequest(bearerToken, queryString);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response
                    .Content
                    .ReadAsStringAsync();

                var albums = JsonSerializer
                    .Deserialize<Albums>(responseContent);

                return albums ?? new Albums();
            }

            throw new HttpRequestException($"Unable to retrieve Artist Albums using the request {queryString}");
        }

        private async Task<HttpResponseMessage> ExecuteGetRequest(string bearerToken, string queryString)
        {
            var httpClient = SetupHttpClient(bearerToken);

            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                new Uri(queryString));

            return await httpClient
                .SendAsync(httpRequestMessage);
        }

        private HttpClient SetupHttpClient(string bearerToken)
        {
            var httpClient = httpClientFactory.CreateClient();

            httpClient
                .DefaultRequestHeaders
                .Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            return httpClient;
        }

        private static void ValidateParameters(string bearerToken, string queryString)
        {
            if (string.IsNullOrWhiteSpace(bearerToken))
            {
                throw new ArgumentNullException(nameof(bearerToken));
            }

            if (string.IsNullOrWhiteSpace(queryString))
            {
                throw new ArgumentNullException(nameof(queryString));
            }
        }
    }
}
