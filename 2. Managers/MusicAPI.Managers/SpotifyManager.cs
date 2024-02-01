﻿using AutoMapper;
using MusicAPI.Accessors.DataTransferObjects;
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
                .Map<ViewModels.UserProfile>(userProfileDto);;
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
                .Map<ViewModels.SearchResult>(searchResultDto);
        }
    }
}
