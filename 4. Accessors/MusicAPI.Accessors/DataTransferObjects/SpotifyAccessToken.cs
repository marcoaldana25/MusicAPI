using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    public class SpotifyAccessToken
    {
        /// <summary>
        /// Default Constructor used to initialize properites.
        /// </summary>
        public SpotifyAccessToken()
        {
            AccessToken = string.Empty;
            TokenType = string.Empty;
            ExpiresIn = 0;
        }

        /// <summary>
        /// Stores the Access Token which is used to maked authorized requests to Spotify's API
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Stores the type of token which is requested. Examples can be Bearer or Refresh.
        /// </summary>
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// Stores the integer value of when the token will expire (in seconds).
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
