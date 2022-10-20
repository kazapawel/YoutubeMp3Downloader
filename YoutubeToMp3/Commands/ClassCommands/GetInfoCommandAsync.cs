using System;
using System.Threading.Tasks;

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
            _viewModel.Url = text;

            _viewModel.StatusMessage = "Getting info...";
            try
            {
                var builder = new StreamDataBuilder();
                var data = await builder.GetStreamData(_viewModel.Url);
                _viewModel.StreamData = data;
                _viewModel.StatusMessage = "Data loaded";
            }
            catch (Exception ex)
            {
                _viewModel.StatusMessage = ex.Message;
            }
        }
    }
}
