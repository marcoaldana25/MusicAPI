namespace MusicAPI.Managers.ViewModels
{
    public class Album
    {
        public string AlbumType { get; set; } = string.Empty;

        public decimal TotalTracks { get; set; } = 0;

        public string[] AvailableMarkets { get; set; } = [];

        public ExternalUrl ExternalUrls { get; set; } = new ExternalUrl();

        public string Href { get; set; } = string.Empty;

        public string Id { get; set; } = string.Empty;

        public Image[] Images { get; set; } = [];

        public string Name { get; set; } = string.Empty;

        public string ReleaseDate { get; set; } = string.Empty;

        public string ReleaseDatePrecision { get; set; } = string.Empty;

        public Restriction Restrictions { get; set; } = new Restriction();

        public string Type { get; set; } = string.Empty;

        public string Uri { get; set; } = string.Empty;

        public Artist[] Artists { get; set; } = [];
    }
}
