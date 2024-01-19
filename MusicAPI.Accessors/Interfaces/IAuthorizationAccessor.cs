namespace MusicAPI.Accessors.Interfaces
{
    public interface IAuthorizationAccessor
    {
        Task<string> RequestAccessTokenAsync();
    }
}
