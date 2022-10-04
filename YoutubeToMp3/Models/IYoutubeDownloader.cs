using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeToMp3
{
    public interface IYoutubeDownloader
    {
        Task DownloadVideoAsync(string url, string userDirectory);
        Task DownloadAudioAsync(string url, string userDirectory);
    }
}
