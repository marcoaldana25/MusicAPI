using AutoMapper;
using MusicAPI.Accessors.Interfaces;
using MusicAPI.Managers.Interfaces;

namespace MusicAPI.Managers
{
    public class SpotifyManager(
            IAuthorizationAccessor authorizationAccessor,
            IMapper mapper,
            ISpotifyAccessor spotifyAccessor) : ISpotifyManager
    {
        public async Task<ViewModels.UserProfile> GetSpotifyAccountAsync()
        {
            var bearerToken = await authorizationAccessor
                .RequestAccessTokenAsync();

            var userProfileDto = await spotifyAccessor
                .GetCurrentUserProfileAsync(bearerToken);

            return mapper
                .Map<ViewModels.UserProfile>(userProfileDto);;
        }
    }
}
