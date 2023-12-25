namespace YoutubeToMp3
{
    public class ApplicationViewModel
    {
        public MainViewModel MainViewModel { get; set; }

        public ApplicationViewModel()
        {
            MainViewModel = new MainViewModel();
        }
    }
}
