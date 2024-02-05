using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    public class ExternalId
    {
        /// <summary>
        /// An international standard code for uniquely identifying sound recordings and music video recordings.
        /// </summary>
        [JsonPropertyName("isrc")]
        public string InternationalStandardRecordingCode { get; set; } = string.Empty;

        /// <summary>
        /// A standard describing a barcode symbology and numbering system used in global trade to identify a specific retail
        /// product type, in a specific packagin configuration, from a specific manufacturer.
        /// </summary>
        [JsonPropertyName("ean")]
        public string InternationalArticleNumber { get; set; } = string.Empty;

        /// <summary>
        /// A barcode symbology that is widely used worldwide for tracking trade items in stores.
        /// </summary>
        [JsonPropertyName("upc")]
        public string UniversalProductCode { get;set; } = string.Empty;
    }
}
