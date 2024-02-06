using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    public class Restriction
    {
        /// <summary>
        /// The reason for the restriction. Albums may be restricted if the content is not available in a given market,
        /// to the user's subscription type, or when the user's account is set to not play explicit content. Allowed values
        /// are market, product, explicit.
        /// </summary>
        [JsonPropertyName("reason")]
        public string Reason { get; set; } = string.Empty;
    }
}
