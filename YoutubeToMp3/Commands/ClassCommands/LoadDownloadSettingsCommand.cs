using YoutubeToMp3.UserSettings;

namespace YoutubeToMp3
{
    public class LoadDownloadSettingsCommand : CommandBase
    {
        private readonly MainViewModel _viewModel;
        private readonly UserSettingsService _userSettingsService;

        public LoadDownloadSettingsCommand(MainViewModel viewModel, UserSettingsService userSettingsService)
        {
            _viewModel = viewModel;
            _userSettingsService = userSettingsService;
        }

        public override void Execute(object parameter)
        {
            _viewModel.DownloadDirectory = _userSettingsService.DownloadDirectory;
            _viewModel.FfmpegPath = _userSettingsService.FfmpegPath;
        }
    }
}
