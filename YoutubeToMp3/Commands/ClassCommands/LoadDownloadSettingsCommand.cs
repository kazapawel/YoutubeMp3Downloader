using YoutubeToMp3.UserSettings;

namespace YoutubeToMp3
{
    public class LoadDownloadSettingsCommand : CommandBase
    {
        private MainViewModel _viewModel;

        public LoadDownloadSettingsCommand(MainViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            var settings = parameter as DownloadSettings;
            _viewModel.DownloadDirectory = settings.DownloadDirectory;
            _viewModel.FfmpegPath = settings.FfmpegPath;
        }
    }
}
