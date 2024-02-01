using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    public class Search
    {

        [JsonPropertyName("q")]
        public string SearchQuery { get; set; } = string.Empty;

        /// <summary>
        /// Search Type for the Spotify Request. NOTE: Needs to be all lowercase.
        /// </summary>
        [JsonPropertyName("type")]
        public string SearchType { get; set; } = string.Empty;

        [JsonPropertyName("market")]
        public string MarketCode { get; set; } = string.Empty;

        [JsonPropertyName("limit")]
        public int? Limit { get; set; } = 20;

        [JsonPropertyName("offset")]
        public int? Offset { get; set; } = 0;

        [JsonPropertyName("include_external")]
        public string? IncludeExternal { get; set; } = string.Empty;
    }
}
