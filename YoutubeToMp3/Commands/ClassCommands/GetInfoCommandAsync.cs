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
            // 
            var text = parameter.ToString();

            // if textbox was cleared clears viewmodel's properties
            if(string.IsNullOrEmpty(text))
            {
                _viewModel.Url = null;
                _viewModel.StreamDataViewModel = null;
                _viewModel.StatusMessage = null;
                return;
            }

            // else updates properties
            _viewModel.Url = text;
            _viewModel.StatusMessage = "Getting info...";

            // starts getting info
            try
            {
                // Gets the stream data async
                var data = await new StreamDataBuilder().GetStreamData(_viewModel.Url);

                // Resfreshes viewmodel properties
                _viewModel.StreamDataViewModel = new StreamDataViewModel(data);
                _viewModel.IsReady = true;
                _viewModel.StatusMessage = "Data loaded. Ready for download.";        
            }
            catch (Exception ex)
            {
                _viewModel.StatusMessage = ex.Message;
            }
        }
    }
}
