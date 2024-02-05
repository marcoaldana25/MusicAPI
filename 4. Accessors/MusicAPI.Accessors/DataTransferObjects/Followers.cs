using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    /// <summary>
    /// Object containing data related to followers associated with the Spotify <see cref="UserProfile"/>
    /// </summary>
    public class Followers
    {
        /// <summary>
        /// This will alwaysb e set to null, as the Web API does not currently support it.
        /// </summary>
        [JsonPropertyName("href")]
        public string Href { get; set; } = string.Empty;

        /// <summary>
        /// Total number of followers.
        /// </summary>
        [JsonPropertyName("total")]
        public decimal Total { get; set; }
    }
}
