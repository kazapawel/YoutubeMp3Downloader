using System;
using System.Windows.Input;

namespace YoutubeToMp3
{
    public class MainViewModel : BaseViewModel
    {
        #region PRIVATE FIELDS

        private StreamData streamDataModel;
        private IYoutubeDownloader youtubeDownloader;
        private string url;
        private string statusMessage;

        #endregion

        #region PUBLIC PROPERTIES

        /// <summary>
        /// Path where downloaded files are stored.
        /// </summary>
        public string UserDirectory { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        /// <summary>
        /// 
        /// </summary>
        public string Title => streamDataModel?.Title;

        /// <summary>
        /// 
        /// </summary>
        public string Duration => streamDataModel?.Duration.ToString();

        /// <summary>
        /// 
        /// </summary>
        public string Author => streamDataModel?.Author;

        /// <summary>
        /// 
        /// </summary>
        public string UploadDate => streamDataModel?.UploadDate.ToString();

        /// <summary>
        /// 
        /// </summary>
        public string Thumbnail => streamDataModel?.Thumbnail;

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

        public ICommand DownloadVideoCommandAsync => new DownloadVideoCommandAsync(this, youtubeDownloader);
        public ICommand DownloadAudioCommandAsync => new DownloadAudioCommandAsync(this, youtubeDownloader);
        public ICommand GetInfoCommandAsync => new GetInfoCommandAsync(this);

        #endregion

        #region CONSTRUCTOR

        public MainViewModel(IYoutubeDownloader yt)
        {
            youtubeDownloader = yt;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void SetNewModel(StreamData model)
        {
            streamDataModel = model;
            youtubeDownloader.StreamData = streamDataModel;
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Author));
            OnPropertyChanged(nameof(Duration));
            OnPropertyChanged(nameof(UploadDate));
            OnPropertyChanged(nameof(Thumbnail));
        }

    }
}
