namespace MusicAPI.Managers.ViewModels
{
    public class Track
    {
        public Album Album { get; set; } = new Album();

        public Artist[] Artists { get; set; } = [];

        public string[] AvailableMarkets { get; set; } = [];

        public int DiscNumber { get; set; } = 0;

        public decimal DurationInMilliseconds { get; set; } = 0;

        public bool IsExplicit { get; set; }

        public ExternalId ExternalIds { get; set; } = new ExternalId();

        public ExternalUrl ExternalUrls { get; set; } = new ExternalUrl();

        public string Href { get; set; } = string.Empty;

        public string Id { get; set; } = string.Empty;

        public bool IsPlayable { get; set; }

        public Restriction Restrictions { get; set; } = new Restriction();

        public string Name { get; set; } = string.Empty;

        public decimal Popularity { get; set; } = 0;

        public string? PreviewUrl { get; set; } = string.Empty;

        public decimal TrackNumber { get; set; } = 0;

        public string Type { get; set; } = string.Empty;

        public string Uri { get; set; } = string.Empty;

        public bool IsLocal { get; set; }
    }
}
