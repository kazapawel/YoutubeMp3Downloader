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

        /// <summary>
        /// Downloads audio async.
        /// </summary>
        /// <returns></returns>
        protected override async Task ExecuteAsync(object parameter)
        {
            if (_viewModel.StreamDataViewModel is null)
                return;

            try
            {
                // Changes state of a view model
                _viewModel.IsReady = false;
                _viewModel.StatusMessage = new InfoMessage("Downloading audio...");

                // Creates download data and downloader
                var downloadData = DownloadDataBuilder.GetDownloadData(_viewModel.StreamDataViewModel.Model);
                var youtubeDownloader = new YoutubeDownloader(downloadData);

                // Downloads audio
                await youtubeDownloader.DownloadAudioAsync();

                // Changes state of a view model
                _viewModel.StatusMessage = new SuccessMessage("Success!");
                _viewModel.IsReady = true;
            }
            catch (Exception ex)
            {
                _viewModel.StatusMessage = new ErrorMessage(ex.Message);
            }
        }

        public void OnIsReadyChanged(object sender, EventArgs e)
        {
            CanExec = _viewModel.IsReady;
        }
    }
}
