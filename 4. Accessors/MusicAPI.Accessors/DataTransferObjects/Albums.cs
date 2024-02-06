using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    public class Albums
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
        public decimal Limit { get; set; } = 0;

        /// <summary>
        /// URL to the next page of items. (null if none)
        /// </summary>
        [JsonPropertyName("next")]
        public string Next { get; set; } = string.Empty;

        /// <summary>
        /// The offset of the items returned (as set in the query or by default).
        /// </summary>
        [JsonPropertyName("offset")]
        public decimal Offset { get; set; } = 0;

        /// <summary>
        /// URL to the previous page of items (null if none).
        /// </summary>
        [JsonPropertyName("previous")]
        public string Previous { get; set; } = string.Empty;

        /// <summary>
        /// The total number of items available to return.
        /// </summary>
        [JsonPropertyName("total")]
        public decimal Total { get; set; } = 0;

        /// <summary>
        /// Array of Albums objects.
        /// </summary>
        [JsonPropertyName("items")]
        public Album[] Items { get; set; }
    }
}
