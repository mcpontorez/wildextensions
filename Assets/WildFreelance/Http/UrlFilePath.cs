
namespace Wild.Freelance.Http
{
    public sealed class UrlFilePath
    {
        public string Url { get; set; }
        public string FilePath { get; set; }

        public UrlFilePath() { }

        public UrlFilePath(string url, string filePath)
        {
            Url = url;
            FilePath = filePath;
        }
    }
}
