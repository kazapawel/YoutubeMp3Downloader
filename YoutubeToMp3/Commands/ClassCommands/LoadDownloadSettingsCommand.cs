﻿using YoutubeToMp3.UserSettings;

namespace YoutubeToMp3
{
    public class LoadDownloadSettingsCommand : CommandBase
    {
        private MainViewModel _viewModel;
        private UserSettingsService _userSettingsService;

        public LoadDownloadSettingsCommand(MainViewModel viewModel)
        {
            _viewModel = viewModel;
            _userSettingsService = new UserSettingsService();
        }

        public override void Execute(object parameter)
        {
            _viewModel.DownloadDirectory = _userSettingsService.DownloadDirectory;
            _viewModel.FfmpegPath = _userSettingsService.FfmpegPath;
        }
    }
}
