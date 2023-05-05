namespace YoutubeToMp3
{
    public class StreamDataViewModel : BaseViewModel
    {
        #region PRIVATE FIELDS

        private readonly StreamData _streamData;

        #endregion

        #region PUBLIC PROPERTIES

        public string Title => _streamData?.Title;
        public string Duration => _streamData?.Duration.ToString();
        public string Author => _streamData?.Author;
        public string UploadDate => _streamData?.UploadDate.Value.Date.ToShortDateString();
        public string Thumbnail => _streamData?.Thumbnail;
        public string VideoQuality => _streamData != null ? _streamData.VideoQuality : string.Empty;
        public string AudioBitrate => _streamData != null ? _streamData.AudioBitrate : string.Empty;
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
