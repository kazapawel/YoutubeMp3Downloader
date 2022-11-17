using YoutubeExplode.Videos.Streams;

namespace YoutubeToMp3
{
    /// <summary>
    /// Data for youtube downloader.
    /// </summary>
    public class DownloadData
    {
        /// <summary>
        /// Stream's title which does not contain problematic characters.
        /// </summary>
        public string FixedTitle { get; set; }

        /// <summary>
        /// User's directory path for downloading files.
        /// </summary>
        public string DownloadPath { get; set; }

        /// <summary>
        /// Path with ffmpeg.exe.
        /// </summary>
        public string FfmpegPath { get; set; }

        /// <summary>
        /// Stream's video to download.
        /// </summary>
        public IStreamInfo VideoHD { get; set; }

        /// <summary>
        /// Stream's audio to download.
        /// </summary>
        public IStreamInfo AudioHD { get; set; }

    }
}
