namespace YoutubeToMp3.ViewModels
{
    public class StreamItemViewModel
    {
        public string Id { get; set; }
        public string VideoName { get; set; }
        public string VideoQuality { get; set; }
        public string VideoContainer { get; set; }
        public string VideoSize { get; set; }
        public string VideoBitrate { get; set; }
        public string VideoCodec { get; set; }
        public string VideoResolution { get; set; }
        public string AudioCodec { get; set; }
        public string AudioContainer { get; set; }
        public string AudioBitrate { get; set; }
        public string AudioSize { get; set; }
        
        /// <summary>
        /// TO DO: Remove this and combine info in front.
        /// </summary>
        public string AudioInfo { get; set; }
    }
}
