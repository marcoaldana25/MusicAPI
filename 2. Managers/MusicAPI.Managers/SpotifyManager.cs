using AutoMapper;
using MusicAPI.Accessors.DataTransferObjects;
using MusicAPI.Accessors.Interfaces;
using MusicAPI.Managers.Interfaces;
using MusicAPI.Managers.ViewModels.Enums;

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

        public async Task GetSearchAsync(
            string searchQuery,
            SearchType searchType,
            string marketCode,
            int limit = 20,
            int offset = 0,
            string includeExternal = "")
        {
            var bearerToken = await authorizationAccessor
                .RequestAccessTokenAsync();

            var searchRequest = new Search
            {
                SearchQuery = searchQuery,
                SearchType = searchType.ToString(),
                MarketCode = marketCode,
                Limit = limit,
                Offset = offset,
                IncludeExternal = includeExternal
            };

            var response = await spotifyAccessor
                .GetSearchAsync(bearerToken, searchRequest);
        }
    }
}
