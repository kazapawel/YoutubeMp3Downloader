namespace YoutubeDownloadService.Commands
{
    public class DownloadMuxedStreamCommand
    {
        public string IdUrl { get; set; }
        public string Url { get; set; }
        public string DownloadPath { get; set; }
    }
}
