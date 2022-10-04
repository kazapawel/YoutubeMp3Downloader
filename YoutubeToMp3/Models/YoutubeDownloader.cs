using System.Linq;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YoutubeToMp3
{
    public class YoutubeDownloader : IYoutubeDownloader
    {
        public async Task DownloadVideoAsync(string url, string userDirectory)
        {
            var youtubeClient = new YoutubeClient();

            // Gets info about movie
            var videos = await youtubeClient.Videos.GetAsync(url);

            
            var streamManifest = await youtubeClient.Videos.Streams.GetManifestAsync(url);
            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
            //var streamInfo = streamManifest.GetVideoStreams().GetWithHighestBitrate();

            //Replaces all '/' and '\' with - to prevent path error
            var title = string.Concat(videos.Title.Select(x => x != '/' ? x : '-'));

            //Downloads video
            await youtubeClient.Videos.Streams.DownloadAsync(streamInfo, @$"{userDirectory}\{title}video.{streamInfo.Container}");
        }

        public async Task DownloadAudioAsync(string url, string userDirectory)
        {
            var youtubeClient = new YoutubeClient();
            var videos = await youtubeClient.Videos.GetAsync(url);
            var streamManifest = await youtubeClient.Videos.Streams.GetManifestAsync(url);
            var streamInfo = streamManifest.GetAudioStreams().GetWithHighestBitrate();

            //Replaces all '/' and '\' with - to prevent path error
            var title = string.Concat(videos.Title.Select(x => x != '/' ? x : '-'));

            await youtubeClient.Videos.Streams.DownloadAsync(streamInfo, @$"{userDirectory}\{title}audio.{streamInfo.Container}");
        }
    }
}
