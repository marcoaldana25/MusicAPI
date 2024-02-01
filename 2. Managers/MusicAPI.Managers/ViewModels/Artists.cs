namespace MusicAPI.Managers.ViewModels
{
    public class Artists
    {
        public string Href { get; set; } = string.Empty;

        public int Limit { get; set; } = 0;

        public string Next { get; set; } = string.Empty;

        public int Offset { get; set; } = 0;

        public string Previous { get; set; } = string.Empty;

        public int Total { get; set; } = 0;

        public Artist[] Items { get; set; } = Array.Empty<Artist>();
    }
}
