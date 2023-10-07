using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeDownloadService;

namespace YoutubeToMp3
{
    public class ApplicationViewModel
    {
        private readonly YoutubeService _youtubeDownloadService;
        public MainViewModel MainViewModel { get; set; }

        public ApplicationViewModel()
        {
            MainViewModel = new MainViewModel();
        }
    }
}
