using MusicAPI.Accessors.Interfaces;
using MusicAPI.Managers.Interfaces;

namespace MusicAPI.Managers
{
    public class SpotifyManager : ISpotifyManager
    {
        private readonly IAuthorizationAccessor _authorizationAccessor;
        private readonly ISpotifyAccessor _spotifyAccessor;

        public SpotifyManager(
            IAuthorizationAccessor authorizationAccessor,
            ISpotifyAccessor spotifyAccessor)
        {
            _authorizationAccessor = authorizationAccessor;
            _spotifyAccessor = spotifyAccessor;
        }

        public async Task<string> GetSpotifyAccountAsync()
        {
            var bearerToken = await _authorizationAccessor
                .RequestAccessTokenAsync();

            await _spotifyAccessor
                .GetCurrentUserProfileAsync(bearerToken);

            return string.Empty;
        }
    }
}
