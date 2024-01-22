using MusicAPI.Accessors.Interfaces;
using MusicAPI.Managers.Interfaces;

namespace MusicAPI.Managers
{
    public class SpotifyManager : ISpotifyManager
    {
        private readonly IAuthorizationAccessor _authorizationAccessor;

        public SpotifyManager(IAuthorizationAccessor authorizationAccessor)
        {
            _authorizationAccessor = authorizationAccessor;
        }

        public async Task<string> GetSpotifyAccountAsync()
        {
            return await _authorizationAccessor
                .RequestAccessTokenAsync();
        }
    }
}
