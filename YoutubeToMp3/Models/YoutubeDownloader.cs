using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YoutubeToMp3
{
    public class YoutubeDownloader : IYoutubeDownloader
    {
        /// <summary>
        /// 
        /// </summary>
        public StreamData StreamData { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public YoutubeDownloader(StreamData streamData)
        {
            StreamData = streamData;
        }

        /// <summary>
        /// For now it downloads muxed stream.
        /// </summary>
        public async Task DownloadVideoAsync(string userDirectory)
        {
            var youtubeClient = new YoutubeClient();
            var title = FixTitle(StreamData.Title);
            await youtubeClient.Videos.Streams.DownloadAsync(StreamData.MuxedHD, @$"{userDirectory}\{title}video.{StreamData.VideoHD.Container}");
        }

        /// <summary>
        /// Downloads audio from given path.
        /// </summary>
        public async Task DownloadAudioAsync(string userDirectory)
        {
            var youtubeClient = new YoutubeClient();
            var title = FixTitle(StreamData.Title);
            await youtubeClient.Videos.Streams.DownloadAsync(StreamData.AudioHD, @$"{userDirectory}\{title}audio.{StreamData.AudioHD.Container}");
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
