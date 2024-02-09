using AutoMapper;
using MusicAPI.Accessors.Interfaces;
using MusicAPI.Engines.Interfaces;
using MusicAPI.Managers.Interfaces;
using MusicAPI.Managers.ViewModels.Enums;

namespace MusicAPI.Managers
{
    public class SpotifyManager(
            IAuthorizationAccessor authorizationAccessor,
            IMapper mapper,
            ISpotifyAccessor spotifyAccessor,
            IQueryEngine queryEngine) : ISpotifyManager
    {
        public async Task<ViewModels.UserProfile> GetSpotifyAccountAsync()
        {
            var bearerToken = await authorizationAccessor
                .RequestAccessTokenAsync();

            var queryString = queryEngine
                .BuildCurrentUserProfileQueryString();

            var userProfileDto = await spotifyAccessor
                .GetCurrentUserProfileAsync(bearerToken, queryString);

            return mapper
                .Map<ViewModels.UserProfile>(userProfileDto) ?? new ViewModels.UserProfile();
        }

        public async Task<ViewModels.SearchResult> GetSearchAsync(
            string searchQuery,
            SearchType searchType,
            string marketCode,
            int? limit = 20,
            int? offset = 0,
            string? includeExternal = "")
        {
            var bearerToken = await authorizationAccessor
                .RequestAccessTokenAsync();

            var queryString = queryEngine
                .BuildSpotifySearchQueryString(
                    searchQuery, 
                    searchType.ToString(), 
                    marketCode, 
                    limit, 
                    offset, 
                    includeExternal);

            var searchResultDto = await spotifyAccessor
                .GetSearchAsync(bearerToken, queryString);

            return mapper
                .Map<ViewModels.SearchResult>(searchResultDto) ?? new ViewModels.SearchResult(); ;
        }

        public async Task<ViewModels.Artist> GetArtistAsync(string artistId)
        {
            var bearerToken = await authorizationAccessor
                .RequestAccessTokenAsync();

            var queryString = queryEngine
                .BuildGetArtistQueryString(artistId);

            var artistDto = await spotifyAccessor
                .GetArtistAsync(bearerToken, queryString);

            return mapper
                .Map<ViewModels.Artist>(artistDto) ?? new ViewModels.Artist(); ;
        }

        public async Task<ViewModels.TopTracks> GetArtistTopTracksAsync(string artistId, string marketCode)
        {
            var bearerToken = await authorizationAccessor
                .RequestAccessTokenAsync();

            var queryString = queryEngine
                .BuildArtistTopTracksQueryString(artistId, marketCode);

            var topTracksDto = await spotifyAccessor
                .GetTopTracksAsync(bearerToken, queryString);

            return mapper
                .Map<ViewModels.TopTracks>(topTracksDto) ?? new ViewModels.TopTracks();
        }

        public async Task<ViewModels.Albums> GetAlbumsAsync(
            string artistId,
            string marketCode,
            string? includeGroups = "",
            int? limit = 20,
            int? offset = 0)
        {
            var bearerToken = await authorizationAccessor
                .RequestAccessTokenAsync();

            var queryString = queryEngine
                .BuildArtistAlbumsQueryString(
                    artistId, 
                    marketCode, 
                    includeGroups, 
                    limit, 
                    offset);

            var albums = await spotifyAccessor
                .GetArtistAlbumsAsync(bearerToken, queryString);

            return mapper
                .Map<ViewModels.Albums>(albums) ?? new ViewModels.Albums();
        }

        public async Task<ViewModels.RelatedArtists> GetRelatedArtistsAsync(string artistId)
        {
            var bearerToken = await authorizationAccessor
                .RequestAccessTokenAsync();

            var queryString = queryEngine
                .BuildRelatedArtistsQueryString(artistId);

            var relatedArtistsDto = await spotifyAccessor
                .GetRelatedArtistsAsync(bearerToken, queryString);

            return mapper
                .Map<ViewModels.RelatedArtists>(relatedArtistsDto) ?? new ViewModels.RelatedArtists();
        }
    }
}
