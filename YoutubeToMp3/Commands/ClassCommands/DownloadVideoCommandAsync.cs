using System;
using System.Threading.Tasks;
using YoutubeDownloadService;
using YoutubeDownloadService.Requests;
using YoutubeExplode.Exceptions;

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
            if (_viewModel.StreamInfoViewModel is null)
                return;

            try
            {
                // Changes state of a view model maybe canexec = false;
                _viewModel.IsReady = false;
                _viewModel.StatusMessage = new InfoMessage("Downloading video...");

                // Maps properties to command
                var command = new DownloadVideoCommand
                {
                    Url = _viewModel.Url,
                    DownloadPath = _viewModel.DownloadPath,
                    FfmpegPath = _viewModel.FfmpegPath,
                    Quality = string.Empty, // for now
                };

                //var downloadData = DownloadDataBuilder.GetDownloadData(_viewModel.StreamInfoViewModel.Model);
                //var youtubeDownloader = new YoutubeDownloader(downloadData);

                // Downloads video
                await YoutubeService.DownloadVideoAsync(command);
                
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
