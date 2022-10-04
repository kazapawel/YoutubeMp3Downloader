using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YoutubeToMp3
{
    public class MainViewModel : BaseViewModel
    {
        #region PRIVATE FIELDS
        private bool isDownloading;
        private string statusMessage;

        #endregion

        #region PUBLIC PROPERTIES
     
        private string title;
        private string duration;
        private string thumbnail;
        private string url;
        private bool gettingInfo;

        public string UserDirectory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            get => title;
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Duration
        {
            get => duration;
            set
            {
                if (duration != value)
                {
                    duration = value;
                    OnPropertyChanged(nameof(Duration));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Thumbnail
        {
            get => thumbnail;
            set
            {
                if (thumbnail != value)
                {
                    thumbnail = value;
                    OnPropertyChanged(nameof(Thumbnail));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Url
        {
            get => url;
            set
            {
                if (url != value)
                {
                    url = value;
                    OnPropertyChanged(nameof(Url));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool GettingInfo
        {
            get => gettingInfo;
            set
            {
                if (gettingInfo != value)
                {
                    gettingInfo = value;
                    OnPropertyChanged(nameof(GettingInfo));
                }
            }
        }

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

        /// <summary>
        /// 
        /// </summary>
        public string StatusMessage
        {
            get => statusMessage;
            set
            {
                if(statusMessage!=value)
                {
                    statusMessage = value;
                    OnPropertyChanged(nameof(StatusMessage));
                }
            }
        }

        #endregion

        #region COMMANDS

        public ICommandAsync DownloadCommandAsync { get; set; }
        public ICommand DownloadVideoClassCommandAsync { get; set; }

        #endregion

        #region CONSTRUCTOR

        public MainViewModel()
        {
            // Sets download directory
            UserDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //Class commands
            DownloadVideoClassCommandAsync = new DownloadVideoCommandAsync(this, new YoutubeDownloader());
        }

        #endregion

        public async Task GetInfoAsync()
        {
            // new youtube client 
            //var youtubeClient = new YoutubeClient();

            // flag
            GettingInfo = true;

            // Gets info about movie
            //var videos = await youtubeClient.Videos.GetAsync(Url);
            
            //SongsListObservable = await Task.Run(() => AddItems(tracksPaths));
            // Sets info properties
            //Title = await Task.Run(() => videos.Title);
            //Duration = await Task.Run(() => videos.Duration.ToString());
            //Thumbnail = await Task.Run(() => videos.Thumbnails[0].Url);

            // flag
        }

        public async Task DownloadVideo()
        {
            // https://www.youtube.com/watch?v=Tqk0Cwt9NzI

            //
            //var streamManifest = await youtubeClient.Videos.Streams.GetManifestAsync(YoutubeUrl);
            //var streamInfo = streamManifest.GetVideoStreams().GetWithHighestBitrate();

            //Sets flag
            //IsDownloading = true;

            // Download stream
            //await youtubeClient.Videos.Streams.DownloadAsync(streamInfo, @$"{userDirectory}\{videos.Title}.{streamInfo.Container}");

            //Sets flag
            //IsDownloading = false;

            // Informs user about succes or failure - to do
        }


    }
}
