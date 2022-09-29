namespace YoutubeToMp3
{
    public class DownloadMovieCommand : CommandBase
    {
        private readonly MainViewModel mainWindowViewModel;

        public DownloadMovieCommand(MainViewModel vm)
        {
            mainWindowViewModel = vm;
        }

        public override void Execute(object parameter)
        {
            mainWindowViewModel.DownloadVideo();
        }
    }
}
