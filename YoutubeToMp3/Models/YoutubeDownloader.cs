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
        public string FfmpegPath => Path.Combine(Directory.GetCurrentDirectory(), "ffmpeg.exe");

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
        /// Downloads 1080p video with sound or if 1080p is no available - highest quality.
        /// </summary>
        public async Task DownloadVideoAsync()
        {
            if (!File.Exists(FfmpegPath))
                throw new FfmpegFileException("Ffmmpeg.exe not found.");

            var title = FixTitle(StreamData.Title);
            var downloadPath = @$"{UserDirectory}\{title}.mp4";
            var infos = new IStreamInfo[]
            {
                StreamData.AudioHD,
                StreamData.VideoHD
            };
            await youtubeClient.Videos.DownloadAsync(infos, new ConversionRequestBuilder(downloadPath).Build());
        }

        /// <summary>
        /// Downloads audio from given path and converts it to mp3.
        /// </summary>
        public async Task DownloadAudioAsync()
        {
            if (!File.Exists(FfmpegPath))
                throw new FfmpegFileException("Ffmmpeg.exe not found.");

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
