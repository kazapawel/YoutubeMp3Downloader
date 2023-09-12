using System;
using System.Threading.Tasks;
using YoutubeDownloadService;

namespace YoutubeToMp3
{
    public class GetInfoCommandAsync : CommandBaseAsync
    {
        private readonly MainViewModel _viewModel;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="vm"></param>
        public GetInfoCommandAsync(MainViewModel vm)
        {
            _viewModel = vm;
        }

        /// <summary>
        /// Gets stream info.
        /// </summary>
        /// <returns></returns>
        protected override async Task ExecuteAsync(object parameter)
        {
            // if textbox was cleared clears viewmodel's properties
            // TO DO: create text cleared event and handle it in view class
            if(string.IsNullOrEmpty(parameter.ToString()))
            {
                _viewModel.StreamInfoViewModel = null;
                _viewModel.StatusMessage = null;
                return;
            }

            // starts getting info
            _viewModel.StatusMessage = new InfoMessage("Getting info...");

            try
            {
                // Gets the stream info async
                var streamInfo = await YoutubeService.GetStreamInfo(_viewModel.Url);

                // Resfreshes viewmodel properties
                _viewModel.StreamInfoViewModel = new StreamInfoViewModel(streamInfo);
                _viewModel.IsReady = true;
                _viewModel.StatusMessage = new SuccessMessage("Data loaded. Ready for download.");        
            }
            catch (Exception ex)
            {
                _viewModel.StatusMessage = new ErrorMessage(ex.Message);
            }
        }
    }
}
