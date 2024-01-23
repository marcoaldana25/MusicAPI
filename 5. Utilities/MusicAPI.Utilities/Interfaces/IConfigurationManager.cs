namespace MusicAPI.Utilities.Interfaces
{
    public interface IConfigurationManager
    {
        string GetSpotifyClientId();

        string GetSpotifyClientSecret();

        string GetSpotifyAuthorizationCode();
    }
}
