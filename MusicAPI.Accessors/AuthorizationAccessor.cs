using MusicAPI.Accessors.Interfaces;

namespace MusicAPI.Accessors
{
    public class AuthorizationAccessor : IAuthorizationAccessor
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private const string BaseUrl = "https://accounts.spotify.com/api/token";

        public AuthorizationAccessor(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> RequestAccessTokenAsync()
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();

                var httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Post,
                    new Uri(BaseUrl));

                var response = await httpClient.SendAsync(httpRequestMessage);

                if (response.IsSuccessStatusCode)
                {
                    return await response
                        .Content
                        .ReadAsStringAsync();
                }

                return string.Empty;

            }
            catch (Exception exception)
            {
                return exception.Message.ToString();
            }
        }
    }
}
