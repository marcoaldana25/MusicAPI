using Microsoft.Extensions.Configuration;
using IConfigurationManager = MusicAPI.Utilities.Interfaces.IConfigurationManager;

namespace MusicAPI.Utilities
{
    public class ConfigurationManager : IConfigurationManager
    {
        private readonly IConfiguration _configuration;

        public ConfigurationManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetSpotifyClientId()
        {
            const string clientIdKey = "SpotifyCredentials:ClientId";

            return GetValue(clientIdKey);
        }

        public string GetSpotifyClientSecret()
        {
            const string clientSecretkey = "SpotifyCredentials:ClientSecret";

            return GetValue(clientSecretkey);
        }

        public string GetSpotifyAuthorizationCode()
        {
            const string authorizationKey = "SpotifyCredentials:AuthorizationCode";

            return GetValue(authorizationKey);
        }

        private string GetValue(string key)
        {
            return _configuration.GetValue<string>(key) ?? string.Empty;
        }


    }
}
