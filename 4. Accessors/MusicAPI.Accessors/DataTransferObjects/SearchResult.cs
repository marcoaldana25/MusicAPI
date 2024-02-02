using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    public class SearchResult
    {
        [JsonPropertyName("artists")]
        public Artists Artists { get; set; } = new Artists();
    }
}
