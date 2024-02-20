namespace MusicAPI.Managers.ViewModels
{
    public class Owner
    {
        public ExternalUrl ExternalUrls { get; set; } = new ExternalUrl();

        public Followers Followers { get; set; } = new Followers();

        public string Href { get; set; } = string.Empty;

        public string Id { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Uri { get; set; } = string.Empty;

        public string DisplayName { get; set; } = string.Empty;
    }
}
