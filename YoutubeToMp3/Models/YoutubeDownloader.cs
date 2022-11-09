using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos.Streams;

namespace YoutubeToMp3
{
    public class YoutubeDownloader : IYoutubeDownloader
    {
        private YoutubeClient youtubeClient = new YoutubeClient();

        /// <summary>
        /// 
        /// </summary>
        public StreamData StreamData { get; set; }

        /// <summary>
        /// Path where downloaded files are stored.
        /// </summary>
        public string UserDirectory { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        /// <summary>
        /// 
        /// </summary>
        public string FfmpegPath => Path.Combine(UserDirectory, "ffmpeg.exe");

        #region CONSTRUCTOR

        /// <summary>
        /// Default constructor.
        /// </summary>
        public YoutubeDownloader(StreamData streamData)
        {
            StreamData = streamData;
        }

        #endregion

        /// <summary>
        /// For now it downloads muxed stream.
        /// </summary>
        public async Task DownloadVideoAsync()
        {
            var title = FixTitle(StreamData.Title);
            var downloadPath = @$"{UserDirectory}\{title}.mp4";
            //await youtubeClient.Videos.Streams.DownloadAsync(StreamData.MuxedHD, @$"{UserDirectory}\{title}video.{StreamData.VideoHD.Container}");
            var infos = new IStreamInfo[]
            {
                StreamData.AudioHD,
                StreamData.VideoHD
            };
            await youtubeClient.Videos.DownloadAsync(infos, new ConversionRequestBuilder(downloadPath).Build());

        }

        /// <summary>
        /// Downloads audio from given path.
        /// </summary>
        public async Task DownloadAudioAsync()
        {
            var title = FixTitle(StreamData.Title);
            var downloadPath = @$"{UserDirectory}\{title}.mp3";
            //await youtubeClient.Videos.Streams.DownloadAsync(StreamData.AudioHD, @$"{UserDirectory}\{title}audio.{StreamData.AudioHD.Container}");
            var infos = new IStreamInfo[]
            {
                StreamData.AudioHD
            };

            await youtubeClient.Videos.DownloadAsync(infos, new ConversionRequestBuilder(downloadPath).Build());
        }

        /// <summary>
        /// Replaces all problematic characters with '-'
        /// </summary>
        private string FixTitle(string title)
        {
            // Collection of problematic characters
            var problems = new HashSet<char>
            {
                '/','?',':','#','%','&','{','}','<','>','*','$','!','@','+','`','|','=','"'
            };

            return string.Concat(title.Select(x => problems.Contains(x) ? '_' : x));
        }
    }
}
