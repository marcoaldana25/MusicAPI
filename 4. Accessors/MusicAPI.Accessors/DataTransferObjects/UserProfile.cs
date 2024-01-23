using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    /// <summary>
    /// Detailed profile information about the current user (including the current user's username).
    /// </summary>
    public class UserProfile
    {
        public UserProfile()
        {
            Country = string.Empty;
            DisplayName = string.Empty;
            EmailAddress = string.Empty;
            ExplicitContentFilter = new ExplicitContentFilter();
            ExternalUrls = new ExternalUrl();
            Followers = new Followers();
            Href = string.Empty;
            Id = string.Empty;
            Images = [];
            Product = string.Empty;
            Type = string.Empty;
            Uri = string.Empty;
        }

        /// <summary>
        /// The countery of the user, as set in the user's account profile. This field is only available when
        /// the current user has granted access to the user-read-private scope.
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// The name displayed on the user's profile.
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The user's email address as entered by the user when creating their account. This field is only available when
        /// the current suer has granted access to the user-read-email scope.
        /// </summary>
        [JsonPropertyName("email")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// The user's explicit content settings. This field is only available when the current user has granted 
        /// access to the user-read-private scope.
        /// </summary>
        [JsonPropertyName("explicit_content")]
        public ExplicitContentFilter ExplicitContentFilter { get; set; }

        /// <summary>
        /// Known external URL's for the user.
        /// </summary>
        [JsonPropertyName("external_urls")]
        public ExternalUrl ExternalUrls { get; set; }

        /// <summary>
        /// Information about the followers of the user.
        /// </summary>
        [JsonPropertyName("followers")]
        public Followers Followers { get; set; }

        /// <summary>
        /// A link to the Web API endpoint for this user.
        /// </summary>
        [JsonPropertyName("href")]
        public string Href { get; set; }

        /// <summary>
        /// The Spotify User ID for the user.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The user's profile image.
        /// </summary>
        [JsonPropertyName("images")]
        public Image[] Images { get; set; }

        /// <summary>
        /// The user's Spotify subscrption level: "premium", "free", etc.
        /// The subscription level "open" can be considered the same as "free". This field is only available when the current
        /// user has granted access to the user-read-private scope.
        /// </summary>
        [JsonPropertyName("product")]
        public string Product { get; set; }

        /// <summary>
        /// The object type: "user"
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The Spotify URI for the user.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }
}
