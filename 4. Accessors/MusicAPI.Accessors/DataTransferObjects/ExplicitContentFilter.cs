using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    /// <summary>
    /// The user's explicit content settings. This field is only available when the current
    /// user has granted access to the user-read-private scope.
    /// </summary>
    public class ExplicitContentFilter
    {
        /// <summary>
        /// When true, indicates that the explict content should not be played.
        /// </summary>
        [JsonPropertyName("filter_enabled")]
        public bool FilterEnabled { get; set; }

        /// <summary>
        /// When true, indicates that the explicit content settings is locked and can't be changed by the user.
        /// </summary>
        [JsonPropertyName("filter_locked")]
        public bool FilterLocked {  get; set; }
    }
}
