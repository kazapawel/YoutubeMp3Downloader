using System.Threading.Tasks;

namespace YoutubeToMp3
{
    public interface IYoutubeDownloader
    {
        DownloadData DownloadData { get; set; }
        Task DownloadVideoAsync();
        Task DownloadAudioAsync();
    }
}
