namespace MusicAPI.Managers.ViewModels
{
    public class SearchResult
    {
        public Albums Albums { get; set; } = new Albums();

        public Artists Artists { get; set; } = new Artists();

        public Playlists Playlists { get; set; } = new Playlists();

        public Tracks Tracks { get; set; } = new Tracks();
    }
}
