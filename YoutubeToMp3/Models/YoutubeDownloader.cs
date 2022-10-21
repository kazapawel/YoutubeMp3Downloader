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
        /// Downloads video with audio from given path.
        /// </summary>
        public async Task DownloadVideoAsync(string userDirectory)
        {
            var youtubeClient = new YoutubeClient();
            var streamInfo = StreamData.StreamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
            var title = FixTitle(StreamData.Videos.Title);
            await youtubeClient.Videos.Streams.DownloadAsync(streamInfo, @$"{userDirectory}\{title}video.{streamInfo.Container}");
        }

        /// <summary>
        /// Downloads audio from given path.
        /// </summary>
        public async Task DownloadAudioAsync(string userDirectory)
        {
            var youtubeClient = new YoutubeClient();

            // excepption if null
            var streamInfo = StreamData.StreamManifest.GetAudioStreams().Where(stream => stream is AudioOnlyStreamInfo).GetWithHighestBitrate();
            var title = FixTitle(StreamData.Videos.Title);
            await youtubeClient.Videos.Streams.DownloadAsync(streamInfo, @$"{userDirectory}\{title}audio.{streamInfo.Container}");
        }

        /// <summary>
        /// Replaces all problematic characters with '-'
        /// </summary>
        private string FixTitle(string title)
        {
            // Collection of problematic characters
            var problems = new HashSet<char>
            {
                '/','?',':','#','%','&','{','}','<','>','*','$','!','@','+','`','|','='
            };

            return string.Concat(title.Select(x => problems.Contains(x) ? '_' : x));
        }
    }
}
