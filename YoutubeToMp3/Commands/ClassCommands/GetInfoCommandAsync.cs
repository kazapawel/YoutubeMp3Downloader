using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YoutubeToMp3
{
    public class GetInfoCommandAsync : CommandBaseAsync
    {
        private readonly MainViewModel _viewModel;

        public GetInfoCommandAsync(MainViewModel vm)
        {
            _viewModel = vm;
        }

        /// <summary>
        /// Gets video data and information about.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(object parameter)
        {
            // this is going to be fixed by binding
            var text = parameter.ToString();

            // if textbox was cleared
            if(string.IsNullOrEmpty(text))
            {
                // this should be another viewmodel
                _viewModel.Url = null;
                _viewModel.StreamDataViewModel = null;
                _viewModel.StatusMessage = null;
                _viewModel.IsUrlValid = false;
                // and an event notification to clear data
                return;
            }

            _viewModel.Url = text;
            _viewModel.StatusMessage = "Getting info...";

            try
            {
                // Creates new builder to get the data
                var builder = new StreamDataBuilder();

                // Gets the stream data async
                var data = await builder.GetStreamData(_viewModel.Url);

                // Resfreshes viewmodel properties
                _viewModel.StreamDataViewModel = new StreamDataViewModel(data);
                _viewModel.IsUrlValid = true;
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
