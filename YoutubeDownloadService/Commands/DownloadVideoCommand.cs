namespace YoutubeDownloadService.Requests
{
    public class DownloadVideoCommand
    {
        public string Url { get; set; }
        public string DownloadPath { get; set; }
        public string FfmpegPath { get; set; }
        public string Quality { get; set; }
    }
}
