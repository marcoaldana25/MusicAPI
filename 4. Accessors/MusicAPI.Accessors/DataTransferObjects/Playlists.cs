using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    public class Playlists : BaseSearchResult
    {
        [JsonPropertyName("items")]
        public Playlist[] Items { get; set; } = [];
    }
}
