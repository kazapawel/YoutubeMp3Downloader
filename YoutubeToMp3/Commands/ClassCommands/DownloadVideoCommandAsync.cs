using System;
using System.Threading.Tasks;

namespace YoutubeToMp3
{
    public class DownloadVideoCommandAsync : CommandBaseAsync
    {
        private readonly MainViewModel _viewModel;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DownloadVideoCommandAsync(MainViewModel vm)
        {
            _viewModel = vm;
            _viewModel.IsReadyChanged += OnIsReadyChanged;
        }

        /// <summary>
        /// Downloads video async.
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
                _viewModel.StatusMessage = new InfoMessage("Downloading video...");

                // Creates download data and downloader
                var downloadData = DownloadDataBuilder.GetDownloadData(_viewModel.StreamDataViewModel.Model);
                var youtubeDownloader = new YoutubeDownloader(downloadData);

                // Downloads video
                await youtubeDownloader.DownloadVideoAsync();
                
                // Changes state of a view model
                _viewModel.StatusMessage = new SuccessMessage("Success!");
                _viewModel.IsReady = true;
            }
            catch (Exception ex)
            {
                _viewModel.StatusMessage = new ErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnIsReadyChanged(object sender, EventArgs e)
        {
            CanExec = _viewModel.IsReady;
        }
    }
}
