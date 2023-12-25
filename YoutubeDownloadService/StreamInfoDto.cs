namespace YoutubeDownloadService
{
    public class StreamInfoDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public TimeSpan? Duration { get; set; }
        public DateTimeOffset? UploadDate { get; set; }
        public string Thumbnail { get; set; }
        public AudioDto AudioHd { get; set; }
        public IEnumerable<VideoDto> VideoStreams { get; set; }
    }
}
