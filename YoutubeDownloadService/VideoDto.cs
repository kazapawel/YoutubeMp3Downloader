﻿namespace YoutubeDownloadService
{
    public class VideoDto
    {
        public string IdUrl { get; set; } 
        public string Name { get; set; }
        public string Quality { get; set; }
        public string Container { get; set; }
        public string Size { get; set; }
        public string Bitrate { get; set; }
        public string VideoCodec { get; set; }
        public string VideoResolution { get; set; }
        public string AudioCodec { get; set; }
    }
}
