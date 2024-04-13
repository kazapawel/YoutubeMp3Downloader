using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeDownloadService;
using YoutubeDownloadService.Commands;
using YoutubeToMp3.ViewModels;

namespace YoutubeToMp3
{
    public class GetInfoCommandAsync : CommandBaseAsync
    {
        private readonly MainViewModel _viewModel;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public GetInfoCommandAsync(MainViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        /// <summary>
        /// Gets stream information.
        /// </summary>
        protected override async Task ExecuteAsync(object parameter)
        {
            // if textbox was cleared clears viewmodel's properties
            // TO DO: create text cleared event and handle it in view class and viewmodel
            if (string.IsNullOrEmpty(parameter.ToString()))
            {
                _viewModel.StreamInfoViewModel = null;
                _viewModel.StatusMessage = null;
                return;
            }

            // starts getting info
            _viewModel.StatusMessage = new InfoMessage("Getting info...");

            try
            {
                var command = new GetStreamInfoCommand
                {
                    Url = _viewModel.Url,
                    FfmpegPath = _viewModel.FfmpegPath,
                };

                // gets stream information, null is handled in catch
                var streamInfoDto = await YoutubeService.GetStreamInfo(command);

                // observable collection for view model
                var videos = new ObservableCollection<StreamItemViewModel>(
                    streamInfoDto.VideoStreams.Select(dto => new StreamItemViewModel
                    {
                        Id = dto.IdUrl,
                        VideoName = dto.Name,
                        VideoQuality = dto.Quality,
                        VideoContainer = dto.Container,
                        VideoSize = dto.Size,
                        VideoBitrate = dto.Bitrate,
                        VideoCodec = dto.VideoCodec,
                        VideoResolution = dto.VideoResolution,
                        AudioContainer = streamInfoDto.AudioHd.Container,
                        AudioBitrate = streamInfoDto.AudioHd.Bitrate,
                        AudioSize = streamInfoDto.AudioHd.Size,
                    }));

                // sets viewmodel properties
                _viewModel.StreamInfoViewModel = new StreamInfoViewModel
                {
                    Title = streamInfoDto.Title,
                    Duration = streamInfoDto.Duration.ToString(),
                    Author = streamInfoDto.Author,
                    UploadDate = streamInfoDto.UploadDate.Value.Date.ToShortDateString(),
                    Thumbnail = streamInfoDto.Thumbnail,
                    Videos = videos,
                    SelectedVideo = videos != null && videos.Any() ? videos[0] : null,
                };

                // notify the view
                _viewModel.StreamInfoViewModel.OnPropertyChanged("Videos");

                // sets flag and message indicating that video is ready to download
                _viewModel.IsReady = true;
                var message =  new SuccessMessage("Data loaded. Ready for download.");

                if (string.IsNullOrWhiteSpace(_viewModel.FfmpegPath))
                {
                    message.AppendSecondaryInfo("Ffmpeg path is not selected. Only muxed streams available");
                }

                _viewModel.StatusMessage = message;
            }
            catch (Exception ex)
            {
                _viewModel.StatusMessage = new ErrorMessage(ex.Message);
            }
        }
    }
}
