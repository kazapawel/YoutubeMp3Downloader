using System;
using System.Windows.Input;
using YoutubeToMp3.UserSettings;
using YoutubeToMp3.ViewModels.Events;

namespace YoutubeToMp3
{
    public class MainViewModel : BaseViewModel
    {
        #region PRIVATE FIELDS

        private StreamInfoViewModel streamInfoViewModel;
        private string _url;
        private string _downloadDirectory;
        private string _ffmpegPath;
        private UserMessage _statusMessage;
        private bool _isBusy;
        private bool _downloadAudioOnly;
        private bool _downloadMp3;
        private readonly UserSettingsService _userSettingsService;

        #endregion

        #region PUBLIC PROPERTIES

        /// <summary>
        /// Youtube stream info data.
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
        /// Youtube video url.
        /// </summary>
        public string Url
        {
            get => _url;
            set
            {
                if (_url != value)
                {
                    _url = value;
                    OnPropertyChanged(nameof(Url));
                }
            }
        }

        /// <summary>
        /// Directory path for saving downloaded files.
        /// </summary>
        public string DownloadDirectory
        {
            get => _downloadDirectory;
            set
            {
                if (_downloadDirectory != value)
                {
                    _downloadDirectory = value;
                    OnPropertyChanged(nameof(DownloadDirectory));
                }
            }
        }

        /// <summary>
        /// Ffmpeg.exe location.
        /// </summary>
        public string FfmpegPath
        {
            get => _ffmpegPath;
            set
            {
                if (_ffmpegPath != value)
                {
                    _ffmpegPath = value;
                    OnPropertyChanged(nameof(FfmpegPath));
                }
            }
        }

        /// <summary>
        /// Information for the user.
        /// </summary>
        public UserMessage StatusMessage
        {
            get => _statusMessage;
            set
            {
                if (_statusMessage != value)
                {
                    _statusMessage = value;
                    OnPropertyChanged(nameof(StatusMessage));
                }
            }
        }

        /// <summary>
        /// Flag for downloading audio only.
        /// </summary>
        public bool DownloadAudioOnly
        {
            get => _downloadAudioOnly;
            set
            {
                if (_downloadAudioOnly != value)
                {
                    _downloadAudioOnly = value;
                    OnPropertyChanged(nameof(DownloadAudioOnly));
                }
            }
        }

        /// <summary>
        /// Flag for downloading audio only in mp3 format.
        /// </summary>
        public bool DownloadMp3
        {
            get => _downloadMp3;
            set
            {
                if (_downloadMp3 != value)
                {
                    _downloadMp3 = value;
                    OnPropertyChanged(nameof(DownloadMp3));
                }
            }
        }

        /// <summary>
        /// Flag for application state.
        /// </summary>
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged(nameof(IsBusy));
                }
            }
        }

        /// <summary>
        /// Occurs when state of readiness has changed.
        /// </summary>
        public event EventHandler<EventArgs<bool>> IsReadyForDownloadChanged;

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

        public void ClearStreamInfo()
        {
            StreamInfoViewModel = null;
        }

        public void SetAsReadyForDownload()
        {
            IsReadyForDownloadChanged?.Invoke(this, new EventArgs<bool>(true));
        }

        public void SetAsNotReadyForDownload()
        {
            IsReadyForDownloadChanged?.Invoke(this, new EventArgs<bool>(false));
        }
    }
}
