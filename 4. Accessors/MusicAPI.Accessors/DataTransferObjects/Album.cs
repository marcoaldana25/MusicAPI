using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    public class Album
    {
        /// <summary>
        /// The type of the album. Allowed values are album, single, compliation.
        /// </summary>
        [JsonPropertyName("album_type")]
        public string AlbumType { get; set; } = string.Empty;

        /// <summary>
        /// The number of tracks in the album.
        /// </summary>
        [JsonPropertyName("total_tracks")]
        public decimal TotalTracks { get; set; } = 0;

        /// <summary>
        /// The markets in which the album is available: ISO 3166-1 alpha-2 country codes.
        /// </summary>
        [JsonPropertyName("available_markets")]
        public string[] AvailableMarkets { get; set; } = [];

        /// <summary>
        /// Known external URL's for this album.
        /// </summary>
        [JsonPropertyName("external_urls")]
        public ExternalUrl ExternalUrls { get; set; } = new ExternalUrl();

        /// <summary>
        /// A link to the Web API endpoint providing full details of the album.
        /// </summary>
        [JsonPropertyName("href")]
        public string Href { get; set; } = string.Empty;

        /// <summary>
        /// The Spotify ID for the album.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The cover art for the album in various sizes, widest first.
        /// </summary>
        [JsonPropertyName("images")]
        public Image[] Images { get; set; } = [];

        /// <summary>
        /// The name of the album. In case of an album takedown, this value may be an empty string.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The date the album was first released.
        /// </summary>
        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; } = string.Empty;

        /// <summary>
        /// The precision with which release_date value is known. Allowed values are year, month, day.
        /// </summary>
        [JsonPropertyName("release_date_precision")]
        public string ReleaseDatePrecision { get; set; } = string.Empty;

        /// <summary>
        /// Included in the response when a content restriction is applied.
        /// </summary>
        [JsonPropertyName("restrictions")]
        public Restriction Restrictions {  get; set; } = new Restriction();
        
        /// <summary>
        /// The object type. Allowed value is album.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// The Spotify URI for the album.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; } = string.Empty;

        /// <summary>
        /// The artists of the album. Each artist object includes a link in href to more detailed information about the artist.
        /// </summary>
        [JsonPropertyName("artists")]
        public Artist[] Artists { get; set; } = []; 
    }
}
