using MusicAPI.Managers.ViewModels.Enums;

namespace MusicAPI.Managers.Interfaces
{
    public interface ISpotifyManager
    {
        Task<ViewModels.UserProfile> GetSpotifyAccountAsync();

        Task GetSearchAsync(
            string searchQuery,
            SearchType searchType,
            string marketCode,
            int limit = 20,
            int offset = 0,
            string includeExternal = "");
    }
}
