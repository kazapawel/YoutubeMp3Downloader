namespace YoutubeToMp3
{
    public class StreamInfoViewModel : BaseViewModel
    {
        #region PUBLIC PROPERTIES

        public string Title { get; set; }
        public string Duration { get; set; }
        public string Author { get; set; }
        public string UploadDate { get; set; }
        public string Thumbnail { get; set; }
        //public string VideoQuality => _streamInfo != null ? _streamInfo.VideoQuality : string.Empty;
        //public string AudioBitrate => _streamInfo != null ? _streamInfo.AudioBitrate : string.Empty;

        #endregion
    }
}
