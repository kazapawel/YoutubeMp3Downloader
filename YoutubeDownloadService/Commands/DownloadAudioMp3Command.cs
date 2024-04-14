namespace YoutubeDownloadService.Commands
{
    public class DownloadAudioMp3Command
    {
        public string Url { get; set; }
        public string DownloadPath { get; set; }
        public string FfmpegPath { get; set; }
    }
}
