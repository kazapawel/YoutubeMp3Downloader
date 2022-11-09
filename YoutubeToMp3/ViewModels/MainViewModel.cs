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
        private bool isReady;

        #endregion

        #region PUBLIC PROPERTIES

        /// <summary>
        /// Viewmodel representing stream data.
        /// </summary>
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
        /// Information for the user about current action.
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

        /// <summary>
        /// Returns true if application is ready to download a stream.
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
