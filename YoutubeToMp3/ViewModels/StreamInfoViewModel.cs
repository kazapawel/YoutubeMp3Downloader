using System.Collections.ObjectModel;
using YoutubeToMp3.ViewModels;

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
        public ObservableCollection<StreamItemViewModel>? Videos { get; set; }
        public StreamItemViewModel SelectedVideo { get; set; }

        #endregion
    }
}
