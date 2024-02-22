using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    public class SearchResult
    {
        [JsonPropertyName("albums")]
        public Albums Albums { get; set; } = new Albums();

        [JsonPropertyName("artists")]
        public Artists Artists { get; set; } = new Artists();

        [JsonPropertyName("playlists")]
        public Playlists Playlists { get; set; } = new Playlists();
    }
}
