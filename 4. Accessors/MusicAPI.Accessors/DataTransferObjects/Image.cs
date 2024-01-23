using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    /// <summary>
    /// Object that contains image data related to the <see cref="UserProfile"/> returned from Spotify
    /// </summary>
    public class Image
    {
        public Image()
        {
            Url = string.Empty;
            Height = 0;
            Width = 0;
        }

        /// <summary>
        /// The source URL of the image.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// The image height in pixels.
        /// </summary>
        [JsonPropertyName("height")]
        public int Height { get; set; }

        /// <summary>
        /// The image width in pixels.
        /// </summary>
        [JsonPropertyName("width")]
        public int Width { get; set; }
    }
}
