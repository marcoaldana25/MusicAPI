using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    public class Tracks : BaseSearchResult
    {
        /// <summary>
        /// An array of Track objects.
        /// </summary>
        [JsonPropertyName("items")]
        public Track[] Items { get; set; } = [];
    }
}
