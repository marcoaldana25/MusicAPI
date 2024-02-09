using MusicAPI.Accessors.DataTransferObjects;
using MusicAPI.Managers.ViewModels.Enums;

namespace MusicAPI.Managers.Interfaces
{
    public interface ISpotifyManager
    {
        /// <summary>
        /// Manager method for directing traffic to retrieve User information from Spotify's Web API.
        /// </summary>
        /// <returns></returns>
        Task<ViewModels.UserProfile> GetSpotifyAccountAsync();

        /// <summary>
        /// Manager method for directing traffic to execute request to Spotify's GET /search endpoint.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="searchType"></param>
        /// <param name="marketCode"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="includeExternal"></param>
        /// <returns></returns>
        Task<ViewModels.SearchResult> GetSearchAsync(
            string searchQuery,
            SearchType searchType,
            string marketCode,
            int? limit = 20,
            int? offset = 0,
            string? includeExternal = "");

        /// <summary>
        /// Manager method for directing traffic to retrieve Artist data from Spotify's GET /artist/{id} endpoint.
        /// </summary>
        /// <param name="artistId"></param>
        /// <returns></returns>
        Task<ViewModels.Artist> GetArtistAsync(string artistId);

        /// <summary>
        /// Manager method for directing traffic to retrieve the Top Tracks for a given 
        /// Artist using Spotify's GET /artist/{id}/top-tracks endpoint.
        /// </summary>
        /// <param name="artistId"></param>
        /// <param name="marketCode"></param>
        /// <returns></returns>
        Task<ViewModels.TopTracks> GetArtistTopTracksAsync(string artistId, string marketCode);

        /// <summary>
        /// Manager method for directing traffic to retrieve Albums for a given
        /// Artist using Spotify's GET /artist/{id}/albums endpoint.
        /// </summary>
        /// <param name="artistId"></param>
        /// <param name="marketCode"></param>
        /// <param name="includeGroups"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        Task<ViewModels.Albums> GetAlbumsAsync(
            string artistId,
            string marketCode,
            string? includeGroups = "",
            int? limit = 20,
            int? offset = 0);

        /// <summary>
        /// Manager method for directing traffic to retrieve related Artists for a given
        /// artist using Spotify's GET /artists/{id}/related-artist endpoint.
        /// </summary>
        /// <param name="artistId"></param>
        /// <returns></returns>
        Task<ViewModels.RelatedArtists> GetRelatedArtistsAsync(string artistId);
    }
}
