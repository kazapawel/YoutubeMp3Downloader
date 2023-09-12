using System;
using System.Threading.Tasks;

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
        /// Gets stream data.
        /// </summary>
        /// <returns></returns>
        protected override async Task ExecuteAsync(object parameter)
        {
            var url = parameter.ToString();

            // if textbox was cleared clears viewmodel's properties
            // TO DO: create text cleared event and handle it in view class
            if(string.IsNullOrEmpty(url))
            {
                _viewModel.StreamDataViewModel = null;
                _viewModel.StatusMessage = null;
                return;
            }

            // starts getting info
            _viewModel.StatusMessage = new InfoMessage("Getting info...");
            try
            {
                // Gets the stream data async
                var data = await StreamDataBuilder.GetStreamData(_viewModel.Url);

                // Resfreshes viewmodel properties
                _viewModel.StreamDataViewModel = new StreamDataViewModel(data);
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
