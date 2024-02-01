using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    public class Artist
    {
        [JsonPropertyName("external_urls")]
        public ExternalUrl ExternalUrl { get; set; } = new ExternalUrl();

        [JsonPropertyName("followers")]
        public Followers Followers { get; set; } = new Followers();

        [JsonPropertyName("genres")]
        public string[] Genres { get; set; } = Array.Empty<string>();

        [JsonPropertyName("href")]
        public string Href { get; set; } = string.Empty;

        [JsonPropertyName("id")]
        public string Id {  get; set; } = string.Empty;

        [JsonPropertyName("images")]
        public Image[] Images { get; set; } = Array.Empty<Image>();

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("popularity")]
        public int Popularity { get; set; } = 0;

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("uri")]
        public string Uri { get; set; } = string.Empty;
    }
}
