using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    /// <summary>
    /// Object containing known external URL's for the <see cref="UserProfile"/>
    /// </summary>
    public class ExternalUrl
    {
        /// <summary>
        /// The Spotify URL for the object.
        /// </summary>
        [JsonPropertyName("spotify")]
        public string Spotify {  get; set; } = string.Empty;
    }
}
