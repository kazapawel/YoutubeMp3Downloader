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

        protected override async Task ExecuteAsync(object parameter)
        {
            // this is going to be fixed by binding
            var text = parameter.ToString();

            // if textbox was cleared
            if(string.IsNullOrEmpty(text))
            {
                // this should be another viewmodel
                _viewModel.Url = null;
                _viewModel.StreamData = null;
                _viewModel.StatusMessage = null;
                _viewModel.IsUrlValid = false;
                // and an event notification to clear data
                return;
            }

            _viewModel.Url = text;
            _viewModel.StatusMessage = "Getting info...";
            try
            {
                var builder = new StreamDataBuilder();
                var data = await builder.GetStreamData(_viewModel.Url);
                _viewModel.StreamData = data;
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
