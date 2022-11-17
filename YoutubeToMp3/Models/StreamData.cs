using System;
using YoutubeExplode.Videos.Streams;

namespace YoutubeToMp3
{
    public class StreamData
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public TimeSpan? Duration { get; set; }
        public DateTimeOffset? UploadDate { get; set;}
        public string Thumbnail { get; set; }
        public string VideoQuality => VideoHD.VideoQuality.ToString();
        public string AudioBitrate => AudioHD.Bitrate.ToString();
        public IVideoStreamInfo VideoHD { get; set; }
        public IStreamInfo AudioHD { get; set; }
        public IStreamInfo MuxedHD { get; set; }
    }
}
