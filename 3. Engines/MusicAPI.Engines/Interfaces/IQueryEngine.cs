namespace MusicAPI.Engines.Interfaces
{
    public interface IQueryEngine
    {
        /// <summary>
        /// Responsible for building a query string that targets Spotify's Web API GET /me endpoint.
        /// </summary>
        /// <returns></returns>
        string BuildCurrentUserProfileQueryString();

        /// <summary>
        /// Responsible for building a query string that targets Spotify's Web API GET /search endpoint.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="searchType"></param>
        /// <param name="marketCode"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="includeExternal"></param>
        /// <returns></returns>
        string BuildSpotifySearchQueryString(
            string searchQuery,
            string searchType,
            string marketCode,
            int? limit,
            int? offset,
            string? includeExternal);

        /// <summary>
        /// Responsible for building a query string that targets Spotify's Web API GET /artists/{id} endpoint.
        /// </summary>
        /// <param name="artistId"></param>
        /// <returns></returns>
        string BuildGetArtistQueryString(string artistId);

        /// <summary>
        /// Responsible for building a query string that targets Spotify's Web API GET /artists/{id}/top-tracks endpoint.
        /// </summary>
        /// <param name="artistId"></param>
        /// <param name="marketCode"></param>
        /// <returns></returns>
        string BuildArtistTopTracksQueryString(string artistId, string marketCode);

        /// <summary>
        /// Responsible for building a query string that targets Spotify's Web API GET /artists/{id}/albums endpoint.
        /// </summary>
        /// <param name="artistId"></param>
        /// <param name="marketCode"></param>
        /// <param name="includeGroups"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        string BuildArtistAlbumsQueryString(
            string artistId, 
            string marketCode, 
            string? includeGroups, 
            int? limit, 
            int? offset);

        /// <summary>
        /// Responsible for building a query string that targets Spotify's Web API GET /artists/{id}/related-artists endpoint.
        /// </summary>
        /// <param name="artistId"></param>
        /// <returns></returns>
        string BuildRelatedArtistsQueryString(string artistId);
    }
}
