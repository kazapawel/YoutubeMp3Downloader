namespace YoutubeDownloadService.Commands
{
    public class DownloadVideoWithAudioCommand
    {
        public string IdUrl { get; set; }
        public string Url { get; set; }
        public string DownloadPath { get; set; }
        public string FfmpegPath { get; set; }
    }
}
