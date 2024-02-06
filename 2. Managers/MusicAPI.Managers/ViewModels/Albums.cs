namespace MusicAPI.Managers.ViewModels
{
    public class Albums
    {
        public string Href { get; set; } = string.Empty;

        public decimal Limit { get; set; } = 0;

        public string Next { get; set; } = string.Empty;

        public decimal Offset { get; set; } = 0;

        public string Previous { get; set; } = string.Empty;

        public decimal Total { get; set; } = 0;

        public Album[] Items { get; set; }
    }
}
