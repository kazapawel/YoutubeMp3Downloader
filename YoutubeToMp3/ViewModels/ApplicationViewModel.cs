using YoutubeDownloadService;

namespace YoutubeToMp3
{
    public class ApplicationViewModel : BaseViewModel
    {
        private readonly YoutubeService _youtubeDownloadService;
        public MainViewModel MainViewModel { get; set; }

        public ApplicationViewModel()
        {
            MainViewModel = new MainViewModel();
        }
    }
}
