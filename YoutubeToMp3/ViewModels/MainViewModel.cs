using System;
using System.Windows.Input;
using YoutubeToMp3.UserSettings;

namespace YoutubeToMp3
{
    public class MainViewModel : BaseViewModel
    {
        #region PRIVATE FIELDS

        private StreamInfoViewModel streamInfoViewModel;
        private string url;
        private string downloadDirectory;
        private string ffmpegPath;
        private UserMessage statusMessage;
        private bool isReady;
        private bool downloadAudioOnly;
        private bool downloadMp3;
        private readonly UserSettingsService _userSettingsService;


        #endregion

        #region PUBLIC PROPERTIES

        /// <summary>
        /// Viewmodel representing stream data.
        /// </summary>
        public StreamInfoViewModel StreamInfoViewModel
        {
            get => streamInfoViewModel;
            set
            {
                if (streamInfoViewModel != value)
                {
                    streamInfoViewModel = value;
                    OnPropertyChanged(nameof(StreamInfoViewModel));
                }
            }
        }

        /// <summary>
        /// Youtube url binded to textbox.
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
        /// Directory path for saving downloaded files.
        /// </summary>
        public string DownloadDirectory
        {
            get => downloadDirectory;
            set
            {
                if(downloadDirectory != value)
                {
                    downloadDirectory = value;
                    OnPropertyChanged(nameof(DownloadDirectory));
                }
            }
        }

        /// <summary>
        /// Ffmpeg.exe location.
        /// </summary>
        public string FfmpegPath
        {
            get => ffmpegPath;
            set
            {
                if (ffmpegPath != value)
                {
                    ffmpegPath = value;
                    OnPropertyChanged(nameof(FfmpegPath));
                }
            }
        }

        /// <summary>
        /// Information for the user about current action.
        /// </summary>
        public UserMessage StatusMessage
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

        public bool DownloadAudioOnly
        {
            get => downloadAudioOnly;
            set
            {
                if (downloadAudioOnly != value)
                {
                    downloadAudioOnly = value;
                    OnPropertyChanged(nameof(DownloadAudioOnly));
                }
            }
        }

        public bool DownloadMp3
        {
            get => downloadMp3;
            set
            {
                if (downloadMp3 != value)
                {
                    downloadMp3 = value;
                    OnPropertyChanged(nameof(DownloadMp3));
                }
            }
        }

        /// <summary>
        /// Returns true if application is ready to download a stream.
        /// Raises IsReadyChanged event.
        /// </summary>
        public bool IsReady
        {
            get => isReady;
            set
            {
                if(isReady!=value)
                {
                    isReady = value;
                    OnPropertyChanged(nameof(IsReady));
                    IsReadyChanged?.Invoke(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Occurs when state of readiness has changed.
        /// </summary>
        public event EventHandler IsReadyChanged;

        #endregion

        #region COMMANDS

        public ICommand GetInfoCommandAsync => new GetInfoCommandAsync(this);
        public ICommand DownloadVideoCommandAsync => new DownloadCommandAsync(this);
        public ICommand ClearUrlCommand => new ClearUrlCommand(this);
        public ICommand LoadDownloadSettingsCommand => new LoadDownloadSettingsCommand(this, _userSettingsService);
        public ICommand SaveDownloadSettingsCommand => new SaveDownloadSettingsCommand(this, _userSettingsService);

        #endregion

        public MainViewModel(UserSettingsService userSettingsService)
        {
            _userSettingsService = userSettingsService;
        }
    }
}
