using System;
using System.Threading.Tasks;

namespace YoutubeToMp3
{
    public class DownloadVideoCommandAsync : CommandBaseAsync
    {
        private readonly MainViewModel _viewModel;

        public DownloadVideoCommandAsync(MainViewModel vm)
        {
            _viewModel = vm;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            _viewModel.StatusMessage = "Downloading video...";
            try
            {
                var youtubeDownloader = new YoutubeDownloader(_viewModel.StreamData);
                await youtubeDownloader.DownloadVideoAsync(_viewModel.UserDirectory);
                _viewModel.StatusMessage = "Success!";
            }
            catch (Exception ex)
            {
                _viewModel.StatusMessage = ex.Message;
            }
        }
    }
}
