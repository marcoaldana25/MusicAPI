namespace MusicAPI.Managers.ViewModels
{
    public class Image
    {
        public Image()
        {
            Url = string.Empty;
            Height = 0;
            Width = 0;
        }

        public string Url { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }
    }
}
