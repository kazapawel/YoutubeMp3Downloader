namespace YoutubeDownloadService.Commands
{
    public class DownloadAudioCommand
    {
        public string Url { get; set; }
        public string DownloadPath { get; set; }
        public string FfmpegPath { get; set; }
        public string Format { get; set; }
    }
}
