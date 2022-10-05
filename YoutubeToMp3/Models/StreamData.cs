using System;
using YoutubeExplode.Videos.Streams;

namespace YoutubeToMp3
{
    public class StreamData
    {
        public string Title => Videos?.Title;
        public string Author => Videos?.Author.ToString();
        public TimeSpan? Duration => Videos?.Duration;
        public DateTimeOffset? UploadDate => Videos?.UploadDate;
        public string Thumbnail => Videos?.Thumbnails[0].Url;

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
