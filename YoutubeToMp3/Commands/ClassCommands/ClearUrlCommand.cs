namespace YoutubeToMp3
{
    public class ClearUrlCommand : CommandBase
    {
        private MainViewModel _viewModel;

        public ClearUrlCommand(MainViewModel vm)
        {
            _viewModel = vm;
        }

        /// <summary>
        /// Erease all  and streams data.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            _viewModel.Url = null;
            _viewModel.StreamDataViewModel = null;
            _viewModel.StatusMessage = null;
            _viewModel.IsUrlValid = false;
            _viewModel.IsReady = false;
        }
    }
}
