using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YoutubeToMp3
{
    public class MainWindowViewModel : BaseViewModel
    {
        private bool isDownloading;

        public string YoutubeUrl { get; set; }
        public string FilePath { get; set; } 

        /// <summary>
        /// Flag to make information about downloading visible.
        /// </summary>
        public bool IsDownloading
        {
            get => isDownloading;
            set
            {
                if(isDownloading!=value)
                {
                    isDownloading = value;
                    OnPropertyChanged(nameof(IsDownloading));
                }
            }
        }
        public ICommand DownloadCommand { get; set; }


        public MainWindowViewModel()
        {
            DownloadCommand = new DownloadMovieCommand(this);
        }

        public async Task DownloadVideo()
        {
            // Sets download directory
            var userDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            
            var youtubeClient = new YoutubeClient();
            var videos = await youtubeClient.Videos.GetAsync(YoutubeUrl);
            var streamManifest = await youtubeClient.Videos.Streams.GetManifestAsync(YoutubeUrl);
            var streamInfo = streamManifest.GetVideoStreams().GetWithHighestBitrate();

            //Sets flag
            IsDownloading = true;

            // Download stream
            await youtubeClient.Videos.Streams.DownloadAsync(streamInfo, @$"{userDirectory}\{videos.Title}.{streamInfo.Container}");

            //
            IsDownloading = false;
        }
    }
}
