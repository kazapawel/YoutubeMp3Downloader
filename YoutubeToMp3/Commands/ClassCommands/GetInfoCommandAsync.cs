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
            _viewModel.StatusMessage = "Getting info...";
            try
            {
                var builder = new StreamDataBuilder();
                var data = await builder.GetStreamData(_viewModel.Url);
                _viewModel.SetNewModel(data);
                _viewModel.StatusMessage = "Data loaded";
            }
            catch (Exception ex)
            {
                _viewModel.StatusMessage = ex.Message;
            }
        }
    }
}
