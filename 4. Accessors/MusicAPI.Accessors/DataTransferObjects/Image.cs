using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    /// <summary>
    /// Object that contains image data related to the <see cref="UserProfile"/> returned from Spotify
    /// </summary>
    public class Image
    {
        /// <summary>
        /// The source URL of the image.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// The image height in pixels.
        /// </summary>
        [JsonPropertyName("height")]
        public decimal Height { get; set; } = 0;

        /// <summary>
        /// The image width in pixels.
        /// </summary>
        [JsonPropertyName("width")]
        public decimal Width { get; set; } = 0;
    }
}
