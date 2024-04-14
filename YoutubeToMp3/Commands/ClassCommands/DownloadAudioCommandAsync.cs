//using System;
//using System.Threading.Tasks;
//using YoutubeDownloadService;
//using YoutubeDownloadService.Commands;

//namespace YoutubeToMp3
//{
//    public class DownloadAudioCommandAsync : CommandBaseAsync
//    {
//        private readonly MainViewModel _viewModel;

//        public DownloadAudioCommandAsync(MainViewModel vm)
//        {
//            _viewModel = vm;
//            _viewModel.IsReadyChanged += OnIsReadyChanged;
//        }

//        /// <summary>
//        /// Downloads audio async.
//        /// </summary>
//        protected override async Task ExecuteAsync(object parameter)
//        {
//            if (_viewModel.StreamInfoViewModel is null)
//                return;

//            try
//            {
//                _viewModel.StatusMessage = new InfoMessage("Downloading audio...");

//                // for disabling all download buttons
//                _viewModel.IsReady = false;

//                // maps request to command
//                var command = new DownloadAudioCommand
//                {
//                    Url = _viewModel.Url,
//                    DownloadPath = _viewModel.DownloadDirectory,
//                    FfmpegPath = _viewModel.FfmpegPath,
//                    Format = string.Empty // for now
//                };

//                // downloads audio
//                await YoutubeService.DownloadAudioAsync(command);

//                // for enabling all download buttons
//                _viewModel.IsReady = true;

//                _viewModel.StatusMessage = new SuccessMessage("Success!");
//            }
//            catch (Exception ex)
//            {
//                _viewModel.StatusMessage = new ErrorMessage(ex.Message);
//            }
//        }

//        /// <summary>
//        /// Sets can execute based on viewmodel IsReady flag.
//        /// </summary>
//        public void OnIsReadyChanged(object sender, EventArgs e)
//        {
//            CanExec = _viewModel.IsReady;
//        }
//    }
//}
