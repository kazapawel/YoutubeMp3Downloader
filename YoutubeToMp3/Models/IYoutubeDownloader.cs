using System.Threading.Tasks;

namespace YoutubeToMp3
{
    public interface IYoutubeDownloader
    {
        StreamData StreamData { get; set; }
        Task DownloadVideoAsync(string url, string userDirectory);
        Task DownloadAudioAsync(string url, string userDirectory);
    }
}
