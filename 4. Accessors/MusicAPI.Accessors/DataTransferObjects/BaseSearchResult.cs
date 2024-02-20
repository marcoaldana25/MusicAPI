using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    public abstract class BaseSearchResult
    {
        /// <summary>
        /// A link to the Web API endpoint returning the full result of the request.
        /// </summary>
        [JsonPropertyName("href")]
        public string Href { get; set; } = string.Empty;

        /// <summary>
        /// The maximum number of items in the reponse (as set in the query or by default).
        /// </summary>
        [JsonPropertyName("limit")]
        public int Limit { get; set; } = 0;

        /// <summary>
        /// URL to the next page of items. (null if none)
        /// </summary>
        [JsonPropertyName("next")]
        public string Next { get; set; } = string.Empty;

        /// <summary>
        /// The offset of the items returned (as set in the query or by default).
        /// </summary>
        [JsonPropertyName("offset")]
        public int Offset { get; set; } = 0;

        /// <summary>
        /// URL to the previous page of items (null if none).
        /// </summary>
        [JsonPropertyName("previous")]
        public string Previous { get; set; } = string.Empty;

        /// <summary>
        /// The total number of items available to return.
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; } = 0;
    }
}
