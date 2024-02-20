namespace MusicAPI.Managers.ViewModels
{
    public class UserProfile
    {
        public string Country { get; set; } = string.Empty;

        public string DisplayName { get; set; } = string.Empty;

        public string EmailAddress { get; set; } = string.Empty;

        public ExplicitContentFilter ExplicitContentFilter { get; set; } = new ExplicitContentFilter();

        public ExternalUrl ExternalUrls { get; set; } = new ExternalUrl();

        public Followers Followers { get; set; } = new Followers();

        public string Href { get; set; } = string.Empty;

        public string Id { get; set; } = string.Empty;

        public Image[] Images { get; set; } = [];

        public string Product { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Uri { get; set; } = string.Empty;
    }
}
