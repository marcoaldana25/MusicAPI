namespace MusicAPI.Managers.Interfaces
{
    public interface ISpotifyManager
    {
        Task<string> GetSpotifyAccountAsync();
    }
}
