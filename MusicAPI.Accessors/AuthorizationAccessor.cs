using MusicAPI.Accessors.Interfaces;

namespace MusicAPI.Accessors
{
    public class AuthorizationAccessor : IAuthorizationAccessor
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthorizationAccessor(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Task<string> RequestAccessToken()
        {
            var httpClient = _httpClientFactory.CreateClient();

            return Task.Run(() => string.Empty);
        }
    }
}
