using System;
using System.Threading.Tasks;

namespace YoutubeToMp3
{
    public class DownloadAudioCommandAsync : CommandBaseAsync
    {
        private readonly MainViewModel _viewModel;

        public DownloadAudioCommandAsync(MainViewModel vm)
        {
            _viewModel = vm;
            _viewModel.IsReadyChanged += OnIsReadyChanged;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            if (_viewModel.StreamDataViewModel is null)
                return;

            try
            {
                _viewModel.IsReady = false;
                _viewModel.StatusMessage = "Downloading audio...";
                var youtubeDownloader = new YoutubeDownloader(_viewModel.StreamDataViewModel.Model);
                await youtubeDownloader.DownloadAudioAsync();
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
