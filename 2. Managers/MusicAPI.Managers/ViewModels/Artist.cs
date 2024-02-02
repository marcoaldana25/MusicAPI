namespace MusicAPI.Managers.ViewModels
{
    public class Artist
    {
        public ExternalUrl ExternalUrl { get; set; } = new ExternalUrl();

        public Followers Followers { get; set; } = new Followers();

        public string[] Genres { get; set; } = [];

        public string Href { get; set; } = string.Empty;

        public string Id { get; set; } = string.Empty;

        public Image[] Images { get; set; } = [];

        public string Name { get; set; } = string.Empty;

        public int Popularity { get; set; } = 0;

        public string Type { get; set; } = string.Empty;

        public string Uri { get; set; } = string.Empty;
    }
}
