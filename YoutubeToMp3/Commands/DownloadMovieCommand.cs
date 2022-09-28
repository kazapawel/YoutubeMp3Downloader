namespace YoutubeToMp3
{
    public class DownloadMovieCommand : CommandBase
    {
        private readonly MainWindowViewModel mainWindowViewModel;

        public DownloadMovieCommand(MainWindowViewModel vm)
        {
            mainWindowViewModel = vm;
        }

        public override void Execute(object parameter)
        {
            mainWindowViewModel.DownloadVideo();
        }
    }
}
