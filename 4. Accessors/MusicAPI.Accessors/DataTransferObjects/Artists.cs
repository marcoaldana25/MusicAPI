using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    public class Artists
    {
        [JsonPropertyName("href")]
        public string Href { get; set; } = string.Empty;

        [JsonPropertyName("limit")]
        public int Limit { get; set; } = 0;

        [JsonPropertyName("next")]
        public string Next { get; set; } = string.Empty;

        [JsonPropertyName("offset")]
        public int Offset {  get; set; } = 0;

        [JsonPropertyName("previous")]
        public string Previous { get; set; } = string.Empty;

        [JsonPropertyName("total")]
        public int Total { get; set; } = 0;

        [JsonPropertyName("items")]
        public Artist[] Items { get; set; } = Array.Empty<Artist>();
    }
}
