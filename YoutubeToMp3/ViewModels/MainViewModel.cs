using System;
using System.Windows.Input;

namespace YoutubeToMp3
{
    public class MainViewModel : BaseViewModel
    {
        #region PRIVATE FIELDS

        private StreamDataViewModel streamDataViewModel;
        private string url;
        private string statusMessage;
        private bool isUrlValid;

        #endregion

        #region PUBLIC PROPERTIES
        public StreamDataViewModel StreamDataViewModel
        {
            get => streamDataViewModel;
            set
            {
                if (streamDataViewModel != value)
                {
                    streamDataViewModel = value;
                    OnPropertyChanged(nameof(StreamDataViewModel));
                }
            }
        }

        /// <summary>
        /// Path where downloaded files are stored.
        /// </summary>
        public string UserDirectory { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

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

        public bool IsUrlValid
        {
            get => isUrlValid;
            set
            {
                if (isUrlValid != value)
                {
                    isUrlValid = value;
                    OnPropertyChanged(nameof(IsUrlValid));
                }
            }
        }

        private bool isReady;
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

        public event EventHandler IsReadyChanged;

        #endregion

        #region COMMANDS

        public ICommand DownloadVideoCommandAsync => new DownloadVideoCommandAsync(this);
        public ICommand DownloadAudioCommandAsync => new DownloadAudioCommandAsync(this);
        public ICommand GetInfoCommandAsync => new GetInfoCommandAsync(this);
        public ICommand ClearUrlCommand => new ClearUrlCommand(this);
        public ICommand PasteClipboardCommand => new PasteClipboardCommand(this);

        #endregion

        #region CONSTRUCTOR

        #endregion
    }
}
