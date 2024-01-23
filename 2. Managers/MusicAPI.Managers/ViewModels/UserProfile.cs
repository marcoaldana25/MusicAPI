namespace MusicAPI.Managers.ViewModels
{
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

        public string Country { get; set; }

        public string DisplayName { get; set; }

        public string EmailAddress { get; set; }

        public ExplicitContentFilter ExplicitContentFilter { get; set; }

        public ExternalUrl ExternalUrls { get; set; }

        public Followers Followers { get; set; }

        public string Href { get; set; }

        public string Id { get; set; }

        public Image[] Images { get; set; }

        public string Product { get; set; }

        public string Type { get; set; }

        public string Uri { get; set; }
    }
}
