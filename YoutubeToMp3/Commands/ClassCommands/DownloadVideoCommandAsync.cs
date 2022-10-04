using System;
using System.Threading.Tasks;

namespace YoutubeToMp3
{
    public class DownloadVideoCommandAsync : CommandBaseAsync
    {
        private readonly MainViewModel _viewModel;
        private readonly IYoutubeDownloader _youtubeDownloader;

        public DownloadVideoCommandAsync(MainViewModel vm, IYoutubeDownloader yt)
        {
            _viewModel = vm;
            _youtubeDownloader = yt;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            _viewModel.StatusMessage = "Downloading...";
            try
            {
                await _youtubeDownloader.DownloadVideoAsync(_viewModel.Url, _viewModel.UserDirectory);
                _viewModel.StatusMessage = "Success!";

            }
            catch (Exception ex)
            {
                _viewModel.StatusMessage = ex.Message;
            }
        }
    }
}
