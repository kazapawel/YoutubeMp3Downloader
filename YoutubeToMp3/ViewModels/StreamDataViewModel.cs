namespace YoutubeToMp3
{
    public class StreamDataViewModel : BaseViewModel
    {
        //public StreamData StreamData
        //{
        //    get => streamData;
        //    set
        //    {
        //        if (streamData != value)
        //        {
        //            streamData = value;
        //            OnPropertyChanged(nameof(StreamData));
        //            OnPropertyChanged(nameof(Title));
        //            OnPropertyChanged(nameof(Author));
        //            OnPropertyChanged(nameof(Duration));
        //            OnPropertyChanged(nameof(UploadDate));
        //            OnPropertyChanged(nameof(Thumbnail));
        //            OnPropertyChanged(nameof(VideoSize));
        //            OnPropertyChanged(nameof(AudioSize));
        //        }
        //    }
        //}

        #region PRIVATE FIELDS

        private readonly StreamData _streamData;

        #endregion

        #region PUBLIC PROPERTIES

        public string Title => _streamData?.Title;
        public string Duration => _streamData?.Duration.ToString();
        public string Author => _streamData?.Author;
        public string UploadDate => _streamData?.UploadDate.ToString();
        public string Thumbnail => _streamData != null ? _streamData?.Thumbnail : "pack://application:,,,/Images/youtube_modern_100.png";
        public string VideoSize => _streamData != null ? _streamData.VideoSize : string.Empty;
        public string AudioSize => _streamData != null ? _streamData.AudioSize : string.Empty;
        public StreamData Model => _streamData;

        #endregion

        #region CONSTRUCTOR

        public StreamDataViewModel(StreamData streamData)
        {
            _streamData = streamData;
        }

        #endregion
    }
}
