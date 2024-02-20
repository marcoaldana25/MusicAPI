using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    public class Playlist
    {
        /// <summary>
        /// True if the owner allows other users to modify the playlist.
        /// </summary>
        [JsonPropertyName("collaborative")]
        public bool Collaborative { get; set; }

        /// <summary>
        /// The playlist description. Only returned for modified, verified playlists, otherwise null.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Known external URL's for this playlist.
        /// </summary>
        [JsonPropertyName("external_urls")]
        public ExternalUrl ExternalUrls { get; set; } = new ExternalUrl();

        /// <summary>
        /// A link to the Web API endpoint providing full details of the playlist.
        /// </summary>
        [JsonPropertyName("href")]
        public string Href { get; set; } = string.Empty;

        /// <summary>
        /// Images for the playlist. The array may be empty or contain up to three images.
        /// </summary>
        [JsonPropertyName("images")]
        public Image[] Images { get; set; } = [];

        /// <summary>
        /// The name of the playlist.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The user who owns the playlist.
        /// </summary>
        [JsonPropertyName("owner")]
        public Owner Owner { get; set; } = new Owner();

        /// <summary>
        /// The playlist's public/private status: true if the playlist is public, false if the playlist is private, null 
        /// if teh playlist status is not relevant.
        /// </summary>
        [JsonPropertyName("public")]
        public bool? Public { get; set; }

        /// <summary>
        /// The version identifier for the current playlist. Can be supplied in other requests to target a specific playlist version.
        /// </summary>
        [JsonPropertyName("snapshot_id")]
        public string SnapshotId { get; set; } = string.Empty;

        /// <summary>
        /// The object type: "Playlist"
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// The Spotify URI for the playlist.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; } = string.Empty;
    }
}
