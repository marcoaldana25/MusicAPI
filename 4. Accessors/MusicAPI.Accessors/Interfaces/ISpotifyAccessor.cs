using MusicAPI.Accessors.DataTransferObjects;

namespace MusicAPI.Accessors.Interfaces
{
    public interface ISpotifyAccessor
    {
        /// <summary>
        /// Communicates with Spotify's Web API to retrieve detailed user information for the current authorized user.
        /// </summary>
        /// <param name="bearerToken"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        Task<UserProfile> GetCurrentUserProfileAsync(string bearerToken, string queryString);

        /// <summary>
        /// Communicates with Spotify's Web API to execute a search criteria based on the provided Query string.
        /// </summary>
        /// <param name="bearerToken"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        Task<SearchResult> GetSearchAsync(string bearerToken, string queryString);

        /// <summary>
        /// Communicates with Spotify's Web API to retrieve catalog information for a single artist.
        /// </summary>
        /// <param name="bearerToken"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        Task<Artist> GetArtistAsync(string bearerToken, string queryString);

        /// <summary>
        /// Communicates with Spotify's Web API to retreive the Top Tracks for a given artist.
        /// </summary>
        /// <param name="bearerToken"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        Task<TopTracks> GetTopTracksAsync(string bearerToken, string queryString);

        /// <summary>
        /// Communicates with Spotify's Web API to retrieve Albums for a given artist.
        /// </summary>
        /// <param name="bearerToken"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        Task<Albums> GetArtistAlbumsAsync(string bearerToken, string queryString);

        /// <summary>
        /// Communicates with Spotify's Web API to retrieve related artists for a given artist.
        /// </summary>
        /// <param name="bearerToken"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        Task<RelatedArtists> GetRelatedArtistsAsync(string bearerToken, string queryString);
    }
}
