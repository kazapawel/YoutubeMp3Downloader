namespace YoutubeToMp3
{
    public class ClearUrlCommand : CommandBase
    {
        private MainViewModel _viewModel;

        public ClearUrlCommand(MainViewModel vm)
        {
            _viewModel = vm;
        }
        public override void Execute(object parameter)
        {
            _viewModel.Url = null;
            _viewModel.StreamData = null;
            _viewModel.StatusMessage = null;
            _viewModel.IsUrlValid = false;
            _viewModel.IsReady = false;
        }
    }
}
