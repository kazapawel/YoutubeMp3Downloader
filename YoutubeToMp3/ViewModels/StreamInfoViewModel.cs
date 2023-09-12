using YoutubeDownloadService;

namespace YoutubeToMp3
{
    public class StreamInfoViewModel : BaseViewModel
    {
        #region PRIVATE FIELDS

        private readonly StreamInfo _streamInfo;

        #endregion

        #region PUBLIC PROPERTIES

        public string Title => _streamInfo?.Title;
        public string Duration => _streamInfo?.Duration.ToString();
        public string Author => _streamInfo?.Author;
        public string UploadDate => _streamInfo?.UploadDate.Value.Date.ToShortDateString();
        public string Thumbnail => _streamInfo?.Thumbnail;
        //public string VideoQuality => _streamInfo != null ? _streamInfo.VideoQuality : string.Empty;
        //public string AudioBitrate => _streamInfo != null ? _streamInfo.AudioBitrate : string.Empty;
        public StreamInfo Model => _streamInfo;

        #endregion

        #region CONSTRUCTOR

        public StreamInfoViewModel(StreamInfo streamInfo)
        {
            _streamInfo = streamInfo;
        }

        #endregion
    }
}
