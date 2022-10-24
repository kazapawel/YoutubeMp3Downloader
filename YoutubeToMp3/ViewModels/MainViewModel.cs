﻿using System;
using System.Windows.Input;

namespace YoutubeToMp3
{
    public class MainViewModel : BaseViewModel
    {
        #region PRIVATE FIELDS

        private StreamData streamData;
        private string url;
        private string statusMessage;

        #endregion

        #region PUBLIC PROPERTIES

        public StreamData StreamData
        {
            get => streamData;
            set
            {
                if(streamData!=value)
                {
                    streamData = value;
                    OnPropertyChanged(nameof(StreamData));
                    OnPropertyChanged(nameof(Title));
                    OnPropertyChanged(nameof(Author));
                    OnPropertyChanged(nameof(Duration));
                    OnPropertyChanged(nameof(UploadDate));
                    OnPropertyChanged(nameof(Thumbnail));
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
        public string Title => StreamData?.Title;

        /// <summary>
        /// 
        /// </summary>
        public string Duration => StreamData?.Duration.ToString();

        /// <summary>
        /// 
        /// </summary>
        public string Author => StreamData?.Author;

        /// <summary>
        /// 
        /// </summary>
        public string UploadDate => StreamData?.UploadDate.ToString();

        /// <summary>
        /// 
        /// </summary>
        public string Thumbnail => StreamData?.Thumbnail;

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

        public ICommand DownloadVideoCommandAsync => new DownloadVideoCommandAsync(this);
        public ICommand DownloadAudioCommandAsync => new DownloadAudioCommandAsync(this);
        public ICommand GetInfoCommandAsync => new GetInfoCommandAsync(this);
        public ICommand ClearUrlCommand => new ClearUrlCommand(this);
        public ICommand PasteClipboardCommand => new PasteClipboardCommand(this);

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainViewModel()
        {
        }

        #endregion
    }
}
