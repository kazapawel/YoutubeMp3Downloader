using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YoutubeToMp3
{
    public class MainViewModel : BaseViewModel
    {
        #region PRIVATE FIELDS

        private string statusMessage;

        #endregion

        #region PUBLIC PROPERTIES

        private string title;
        private string duration;
        private string thumbnail;
        private string url;

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
        public string StatusMessage
        {
            get => statusMessage;
            set
            {
                if (statusMessage != value)
                {
                    statusMessage = value;
                    OnPropertyChanged(nameof(StatusMessage));
                }
            }
        }

        #endregion

        #region COMMANDS

        public ICommand DownloadVideoCommandAsync { get; set; }
        public ICommand DownloadAudioCommandAsync { get; set; }

        #endregion

        #region CONSTRUCTOR

        public MainViewModel()
        {
            // Sets download directory
            UserDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //Class commands
            DownloadVideoCommandAsync = new DownloadVideoCommandAsync(this, new YoutubeDownloader());
            DownloadAudioCommandAsync = new DownloadAudioCommandAsync(this, new YoutubeDownloader());
        }

        #endregion

    }
}
