namespace YoutubeDownloadService
{
    public class StreamInfoDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public TimeSpan? Duration { get; set; }
        public DateTimeOffset? UploadDate { get; set; }
        public string Thumbnail { get; set; }
        public AudioStreamDto AudioHd { get; set; }
        public IEnumerable<VideoStreamDto> VideoStreams { get; set; }
    }
}
