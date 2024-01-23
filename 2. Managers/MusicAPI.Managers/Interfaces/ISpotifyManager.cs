namespace MusicAPI.Managers.Interfaces
{
    public interface ISpotifyManager
    {
        Task<ViewModels.UserProfile> GetSpotifyAccountAsync();
    }
}
