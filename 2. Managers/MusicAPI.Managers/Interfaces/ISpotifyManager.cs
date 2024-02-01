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
        Task GetSearchAsync(
            string searchQuery,
            SearchType searchType,
            string marketCode,
            int? limit = 20,
            int? offset = 0,
            string? includeExternal = "");
    }
}
