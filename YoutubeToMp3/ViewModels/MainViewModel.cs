﻿using System;
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
        public ICommand DownloadVideoCommandAsync => new DownloadVideoCommandAsync(this);
        public ICommand DownloadAudioCommandAsync => new DownloadAudioCommandAsync(this); 
        public ICommand ClearUrlCommand => new ClearUrlCommand(this);
        public ICommand LoadDownloadSettingsCommand => new LoadDownloadSettingsCommand(this);
        public ICommand SaveDownloadSettingsCommand => new SaveDownloadSettingsCommand(this);

        #endregion

        public MainViewModel()
        {
            //DownloadDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //FfmpegPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/Ffmpeg.exe";
        }
    }
}
