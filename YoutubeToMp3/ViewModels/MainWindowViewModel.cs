using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YoutubeToMp3
{
    public class MainWindowViewModel : BaseViewModel
    {
        public string YoutubeUrl { get; set; }
        public string FilePath { get; set; } = @"C:\Users\Public\Desktop\ytdownloads\";
        public ICommand DownloadCommand { get; set; }

        public MainWindowViewModel()
        {
            DownloadCommand = new DownloadMovieCommand(this);
        }

        public async Task DownloadVideo()
        {
            var dir = Directory.GetCurrentDirectory();
            //Directory.SetCurrentDirectory(@"C:\Users\Public\Desktop\ytdownloads\");
            //dir = Directory.GetCurrentDirectory();
            var youtubeClient = new YoutubeClient();

            // Videos data
            var videos = await youtubeClient.Videos.GetAsync(YoutubeUrl);

            var streamManifest = await youtubeClient.Videos.Streams.GetManifestAsync(YoutubeUrl);
            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
            var stream = await youtubeClient.Videos.Streams.GetAsync(streamInfo);

            // Download stream
            //await youtubeClient.Videos.Streams.DownloadAsync(streamInfo, FilePath);
            await youtubeClient.Videos.Streams.DownloadAsync(streamInfo, $"video.{streamInfo.Container}");
        }
    }
}
