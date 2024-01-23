namespace MusicAPI.Accessors.Interfaces
{
    public interface ISpotifyAccessor
    {
        Task GetCurrentUserProfileAsync(string bearerToken);
    }
}
