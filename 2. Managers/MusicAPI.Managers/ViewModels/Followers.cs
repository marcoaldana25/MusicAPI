namespace MusicAPI.Managers.ViewModels
{
    public class Followers
    {
        public Followers()
        {
            Href = string.Empty;
            Total = 0;
        }

        public string Href { get; set; }

        public int Total { get; set; }
    }
}
