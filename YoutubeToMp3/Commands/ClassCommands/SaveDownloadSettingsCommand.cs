using YoutubeToMp3.UserSettings;

namespace YoutubeToMp3
{
    public class SaveDownloadSettingsCommand : CommandBase
    {
        private MainViewModel _viewModel;
        private UserSettingsService _userSettingsService;

        public SaveDownloadSettingsCommand(MainViewModel viewModel, UserSettingsService userSettingsService)
        {
            _viewModel = viewModel;
            _userSettingsService = userSettingsService;
        }

        public override void Execute(object parameter)
        {
            _userSettingsService.DownloadDirectory = _viewModel.DownloadDirectory;
            _userSettingsService.FfmpegPath = _viewModel.FfmpegPath;
            _userSettingsService.SaveSettings();
        }
    }
}
