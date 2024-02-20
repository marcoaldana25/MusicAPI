using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    public class Track
    {
        /// <summary>
        /// The album on which the track apperas. The album object includes a link in href to full information about the album.
        /// </summary>
        [JsonPropertyName("album")]
        public Album Album { get; set; } = new Album();

        /// <summary>
        /// The artists who performed the track. Each artist object includes a link in href to more detailed information
        /// about the artist.
        /// </summary>
        [JsonPropertyName("artists")]
        public Artist[] Artists { get; set; } = [];

        /// <summary>
        /// A list of countries in which the track can be played, identified by their ISO 3166-1 alpha-2 code.
        /// </summary>
        [JsonPropertyName("available_markets")]
        public string[] AvailableMarkets { get; set; } = [];

        /// <summary>
        /// The disc number (usually 1 unless the album consists of more than one disc.)
        /// </summary>
        [JsonPropertyName("disc_number")]
        public int DiscNumber { get; set; } = 0;

        /// <summary>
        /// The track length in milliseconds.
        /// </summary>
        [JsonPropertyName("duration_ms")]
        public decimal DurationInMilliseconds { get; set; } = 0;

        /// <summary>
        /// Whether or not the track has explicit lyrics (true if yes it does, false if no OR unknown).
        /// </summary>
        [JsonPropertyName("explicit")]
        public bool IsExplicit { get; set; }

        /// <summary>
        /// Known external ID's for the track.
        /// </summary>
        [JsonPropertyName("external_ids")]
        public ExternalId ExternalIds { get; set; } = new ExternalId();

        /// <summary>
        /// Known external URL's for this track.
        /// </summary>
        [JsonPropertyName("external_urls")]
        public ExternalUrl ExternalUrls { get; set; } = new ExternalUrl();

        /// <summary>
        /// A link to the Web API endpoint providing full details of the track.
        /// </summary>
        [JsonPropertyName("href")]
        public string Href { get; set; } = string.Empty;

        /// <summary>
        /// The Spotify ID for the track.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Part of the response when Track Relinking is applied. If true, the track is playable in the given
        /// market. Otherwise false.
        /// </summary>
        [JsonPropertyName("is_playable")]
        public bool IsPlayable { get; set; }

        /// <summary>
        /// Included in the response when a content restriction is applied.
        /// </summary>
        [JsonPropertyName("restrictions")]
        public Restriction Restrictions { get; set; } = new Restriction();

        /// <summary>
        /// The name of the track.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The popularity of the track. The value will be between 0 and 100, with 100 being the most popular.
        /// </summary>
        [JsonPropertyName("popularity")]
        public decimal Popularity { get; set; } = 0;

        /// <summary>
        /// A link to a 30 second preview (MP3 format) of the track. Can be null.
        /// </summary>
        [JsonPropertyName("preview_url")]
        public string? PreviewUrl { get; set; } = string.Empty;

        /// <summary>
        /// The number of the Track. If an album has several discs, the track number is the number of the specified disc.
        /// </summary>
        [JsonPropertyName("track_number")]
        public decimal TrackNumber { get; set; } = 0;

        /// <summary>
        /// The object type: "Track".
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// The Spotify URI for the track.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; } = string.Empty;

        /// <summary>
        /// Whether or not the track is from a local file.
        /// </summary>
        [JsonPropertyName("is_local")]
        public bool IsLocal { get; set; }
    }
}
