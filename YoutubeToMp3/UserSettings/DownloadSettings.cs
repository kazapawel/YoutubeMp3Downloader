using System.Configuration;

namespace YoutubeToMp3.UserSettings
{
    public class DownloadSettings : ConfigurationSection
    {
        [ConfigurationProperty("download_directory")]
        public string DownloadDirectory
        {
            get => (string)this["download_directory"];
            set
            {
                this["download_directory"] = value;
            }
        }

        [ConfigurationProperty("ffmpeg_path")]
        public string FfmpegPath
        {
            get => (string)this["ffmpeg_path"];
            set
            {
                this["ffmpeg_path"] = value;
            }
        }
    }
}
