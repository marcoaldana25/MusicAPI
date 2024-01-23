using MusicAPI.Accessors.DataTransferObjects;

namespace MusicAPI.Accessors.Interfaces
{
    public interface ISpotifyAccessor
    {
        Task<UserProfile> GetCurrentUserProfileAsync(string bearerToken);
    }
}
