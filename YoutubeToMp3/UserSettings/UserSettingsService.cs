using System.Configuration;

namespace YoutubeToMp3.UserSettings
{
    public class UserSettingsService
    {
        private Configuration _appConfig;
        private DownloadSettings _downloadSettings;

        public string DownloadDirectory
        {
            get => _downloadSettings.DownloadDirectory;
            set => _downloadSettings.DownloadDirectory = value;
        }

        public string FfmpegPath
        {
            get => _downloadSettings.FfmpegPath;
            set => _downloadSettings.FfmpegPath = value;
        }

        public UserSettingsService()
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            _appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (_appConfig.Sections["download_settings"] is null)
            {
                _appConfig.Sections.Add("download_settings", new DownloadSettings());
            }

            _downloadSettings = _appConfig.GetSection("download_settings") as DownloadSettings;
        }

        public void SaveSettings()
        {
            _downloadSettings.DownloadDirectory = DownloadDirectory;
            _downloadSettings.FfmpegPath = FfmpegPath;
            _appConfig.Save();
        }
    }
}
