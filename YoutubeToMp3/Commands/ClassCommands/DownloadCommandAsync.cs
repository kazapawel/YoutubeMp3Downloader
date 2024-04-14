using System;
using System.Threading.Tasks;
using YoutubeDownloadService;
using YoutubeDownloadService.Commands;

namespace YoutubeToMp3
{
    public class DownloadCommandAsync : CommandBaseAsync
    {
        private readonly MainViewModel _viewModel;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DownloadCommandAsync(MainViewModel vm)
        {
            _viewModel = vm;
            _viewModel.IsReadyChanged += OnIsReadyChanged;
        }

        /// <summary>
        /// Downloads video async.
        /// </summary>
        protected override async Task ExecuteAsync(object parameter)
        {
            if (_viewModel.StreamInfoViewModel is null)
            {
                _viewModel.StatusMessage = new ErrorMessage("Something went wrong.");
                return;
            }

            if (_viewModel.StreamInfoViewModel.SelectedVideo is null)
            {
                _viewModel.StatusMessage = new InfoMessage("No output selected.");
                return;
            }

            try
            {
                _viewModel.StatusMessage = new InfoMessage("Downloading...");

                // for disabling all download buttons
                _viewModel.IsReady = false;

                // command mapping
                if (_viewModel.DownloadMp3)
                {
                    // AUDIO MP3
                    var command = new DownloadAudioMp3Command
                    {
                        Url = _viewModel.Url,
                        DownloadPath = _viewModel.DownloadDirectory,
                        FfmpegPath = _viewModel.FfmpegPath,
                    };

                    await YoutubeService.DownloadAudioMp3Async(command);
                }

                if (_viewModel.DownloadAudioOnly)
                {
                    // AUDIO HQ
                    var command = new DownloadAudioCommand
                    {
                        Url = _viewModel.Url,
                        DownloadPath = _viewModel.DownloadDirectory,
                    };

                    await YoutubeService.DownloadAudioHqAsync(command);
                }
                else
                {
                    // MUXED STREAM
                    if (string.IsNullOrWhiteSpace(_viewModel.FfmpegPath))
                    {
                        var command = new DownloadMuxedStreamCommand
                        {
                            IdUrl = _viewModel.StreamInfoViewModel.SelectedVideo.Id,
                            Url = _viewModel.Url,
                            DownloadPath = _viewModel.DownloadDirectory,
                        };

                        await YoutubeService.DownloadMuxedStream(command);
                    }
                    else
                    {
                        // VIDEO with AUDIO HQ
                        var command = new DownloadVideoWithAudioCommand
                        {
                            IdUrl = _viewModel.StreamInfoViewModel.SelectedVideo.Id,
                            Url = _viewModel.Url,
                            DownloadPath = _viewModel.DownloadDirectory,
                            FfmpegPath = _viewModel.FfmpegPath,
                        };

                        // downloads video
                        await YoutubeService.DownloadVideoWithAduioHqAsync(command);
                    }
                }
                // for enabling all download buttons
                _viewModel.IsReady = true;

                _viewModel.StatusMessage = new SuccessMessage("Success!");
            }
            catch (Exception ex)
            {
                _viewModel.StatusMessage = new ErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// Sets can execute based on viewmodel IsReady flag.
        /// </summary>
        private void OnIsReadyChanged(object? sender, EventArgs e)
        {
            CanExec = _viewModel.IsReady;
        }
    }
}
