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
        public string VideoSize => VideoHD.Size.ToString();
        public string AudioSize => AudioHD.Size.ToString();

        public IStreamInfo VideoHD { get; set; }
        public IStreamInfo AudioHD { get; set; }
        public IStreamInfo MuxedHD { get; set; }

        /// <summary>
        /// Metadata associated with a YouTube video.
        /// </summary>
        public YoutubeExplode.Videos.Video Videos { get; set; }
        
        /// <summary>
        /// Contains information about available media streams on a YouTube video.
        /// </summary>
        public StreamManifest StreamManifest { get; set; }

    }
}
