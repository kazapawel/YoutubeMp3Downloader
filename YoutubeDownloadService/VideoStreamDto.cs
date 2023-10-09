using System.Drawing;

namespace YoutubeDownloadService
{
    public class VideoStreamDto
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Bitrate { get; set; }
        public string VideoCodec { get; set; }
        public string VideoResolution { get; set; }
    }
}
