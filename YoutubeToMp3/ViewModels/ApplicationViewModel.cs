namespace YoutubeToMp3
{
    public class ApplicationViewModel : BaseViewModel
    {
        public MainViewModel MainViewModel { get; set; }

        public ApplicationViewModel()
        {
            MainViewModel = new MainViewModel();
        }
    }
}
