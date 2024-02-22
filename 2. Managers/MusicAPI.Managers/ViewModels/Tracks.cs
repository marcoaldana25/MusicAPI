namespace MusicAPI.Managers.ViewModels
{
    public class Tracks : BaseSearchResult
    {
        public Track[] Items { get; set; } = [];
    }
}
