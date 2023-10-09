namespace YoutubeDownloadService
{
    public class StreamInfoDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public TimeSpan? Duration { get; set; }
        public DateTimeOffset? UploadDate { get; set; }
        public string Thumbnail { get; set; }

        public IEnumerable<VideoStreamDto> VideoStreams { get; set; }
        public IEnumerable<AudioStreamDto> AudioStreams { get; set; }
        //public string VideoQuality => VideoHD.VideoQuality.ToString();
        //public string AudioBitrate => AudioHD.Bitrate.ToString();
        //public IVideoStreamInfo VideoHD { get; set; }
        //public IStreamInfo AudioHD { get; set; }
        //public IStreamInfo MuxedHD { get; set; }
    }
}
