using AutoMapper;
using MusicAPI.Accessors.Interfaces;
using MusicAPI.Managers.Interfaces;

namespace MusicAPI.Managers
{
    public class SpotifyManager : ISpotifyManager
    {
        private readonly IAuthorizationAccessor _authorizationAccessor;
        private readonly IMapper _mapper;
        private readonly ISpotifyAccessor _spotifyAccessor;

        public SpotifyManager(
            IAuthorizationAccessor authorizationAccessor,
            IMapper mapper,
            ISpotifyAccessor spotifyAccessor)
        {
            _authorizationAccessor = authorizationAccessor;
            _mapper = mapper;
            _spotifyAccessor = spotifyAccessor;
        }

        public async Task<ViewModels.UserProfile> GetSpotifyAccountAsync()
        {
            var bearerToken = await _authorizationAccessor
                .RequestAccessTokenAsync();

            var userProfileDto = await _spotifyAccessor
                .GetCurrentUserProfileAsync(bearerToken);

            return _mapper
                .Map<ViewModels.UserProfile>(userProfileDto);;
        }
    }
}
