using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeToMp3
{
    public class DownloadAudioCommandAsync : CommandBaseAsync
    {
        private readonly MainViewModel _viewModel;
        private readonly IYoutubeDownloader _youtubeDownloader;

        public DownloadAudioCommandAsync(MainViewModel vm, IYoutubeDownloader yt)
        {
            _viewModel = vm;
            _youtubeDownloader = yt;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            _viewModel.StatusMessage = "Downloading audio...";
            try
            {
                await _youtubeDownloader.DownloadAudioAsync(_viewModel.Url, _viewModel.UserDirectory);
                _viewModel.StatusMessage = "Success!";
            }
            catch (Exception ex)
            {
                _viewModel.StatusMessage = ex.Message;
            }
        }
    }
}
