using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    public class RelatedArtists
    {
        /// <summary>
        /// An array of Artist Object.
        /// </summary>
        [JsonPropertyName("artists")]
        public Artist[] Artists { get; set; } = [];
    }
}
