using System;
using System.Threading.Tasks;

namespace YoutubeToMp3
{
    public class DownloadVideoCommandAsync : CommandBaseAsync
    {
        private readonly MainViewModel _viewModel;

        /// <summary>
        /// Default constructor
        /// </summary>
        public DownloadVideoCommandAsync(MainViewModel vm)
        {
            _viewModel = vm;
            _viewModel.IsReadyChanged += OnIsReadyChanged;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override async Task ExecuteAsync(object parameter)
        {
            if (_viewModel.StreamDataViewModel is null)
                return;

            try
            {
                _viewModel.IsReady = false;
                _viewModel.StatusMessage = "Downloading video...";
                var youtubeDownloader = new YoutubeDownloader(_viewModel.StreamDataViewModel.Model);
                await youtubeDownloader.DownloadVideoAsync();
                _viewModel.StatusMessage = "Success!";
                _viewModel.IsReady = true;
            }
            catch (Exception ex)
            {
                _viewModel.StatusMessage = ex.Message;
            }
        }

        public void OnIsReadyChanged(object sender, EventArgs e)
        {
            CanExec = _viewModel.IsReady;
        }
    }
}
