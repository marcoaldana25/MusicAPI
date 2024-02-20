namespace MusicAPI.Managers.ViewModels
{
    public abstract class BaseSearchResult
    {
        public string Href { get; set; } = string.Empty;

        public decimal Limit { get; set; } = 0;

        public string Next { get; set; } = string.Empty;

        public decimal Offset { get; set; } = 0;

        public string Previous { get; set; } = string.Empty;

        public decimal Total { get; set; } = 0;
    }
}
