using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    public class Albums : BaseSearchResult
    {
        /// <summary>
        /// Array of Albums objects.
        /// </summary>
        [JsonPropertyName("items")]
        public Album[] Items { get; set; } = [];
    }
}
