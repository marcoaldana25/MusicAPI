using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    public class TopTracks
    {
        /// <summary>
        /// An array of Track objects.
        /// </summary>
        [JsonPropertyName("tracks")]
        public Track[] Tracks { get; set; } = [];
    }
}
