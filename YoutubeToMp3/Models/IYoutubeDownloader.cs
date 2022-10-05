using System.Threading.Tasks;

namespace YoutubeToMp3
{
    public interface IYoutubeDownloader
    {
        StreamData StreamData { get; set; }
        Task DownloadVideoAsync(string userDirectory);
        Task DownloadAudioAsync(string userDirectory);
    }
}
