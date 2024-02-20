namespace MusicAPI.Managers.ViewModels
{
    public class Playlist
    {
        public bool Collaborative { get; set; }

        public string Description { get; set; } = string.Empty;

        public ExternalUrl ExternalUrls { get; set; } = new ExternalUrl();

        public string Href { get; set; } = string.Empty;

        public Image[] Images { get; set; } = [];

        public string Name { get; set; } = string.Empty;

        public Owner Owner { get; set; } = new Owner();

        public bool? Public { get; set; }

        public string SnapshotId { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Uri { get; set; } = string.Empty;
    }
}