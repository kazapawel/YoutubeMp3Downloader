using System.IO;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos.Streams;

namespace YoutubeToMp3
{
    public class YoutubeDownloader : IYoutubeDownloader
    {
        private YoutubeClient youtubeClient = new YoutubeClient();
        public DownloadData DownloadData { get; set; }

        #region CONSTRUCTOR

        public YoutubeDownloader(DownloadData downloadData)
        {
            DownloadData = downloadData;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Downloads 1080p video with sound or if 1080p is no available - highest quality.
        /// </summary>
        public async Task DownloadVideoAsync()
        {
            //if (!File.Exists(DownloadData.FfmpegPath))
            //    throw new FFmpegNotFoundException();

            var downloadPath = @$"{DownloadData.DownloadPath}\{DownloadData.FixedTitle}.mp4";
            var infos = new IStreamInfo[]
            {
                DownloadData.AudioHD,
                DownloadData.VideoHD
            };
            await youtubeClient.Videos.DownloadAsync(infos, new ConversionRequestBuilder(downloadPath).Build());
        }

        /// <summary>
        /// Downloads audio from given path and converts it to mp3.
        /// </summary>
        public async Task DownloadAudioAsync()
        {
            //if (!File.Exists(DownloadData.FfmpegPath))
            //    throw new FFmpegNotFoundException();
            var downloadPath = @$"{DownloadData.DownloadPath}\{DownloadData.FixedTitle}.mp3";
            var infos = new IStreamInfo[]
            {
                DownloadData.AudioHD
            };

            await youtubeClient.Videos.DownloadAsync(infos, new ConversionRequestBuilder(downloadPath).Build());
        }

        #endregion
    }
}
