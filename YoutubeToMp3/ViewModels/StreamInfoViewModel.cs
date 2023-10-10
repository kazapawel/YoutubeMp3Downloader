using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using YoutubeDownloadService;

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
        public ObservableCollection<VideoStreamDto>? Videos { get; set; }
        public VideoStreamDto SelectedVideo { get; set; }

        #endregion
    }
}
