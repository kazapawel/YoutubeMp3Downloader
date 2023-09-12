namespace YoutubeToMp3
{
    public class ClearUrlCommand : CommandBase
    {
        private MainViewModel _viewModel;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="vm"></param>
        public ClearUrlCommand(MainViewModel vm)
        {
            _viewModel = vm;
        }

        /// <summary>
        /// Clears viewmodel properties.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            _viewModel.Url = null;
            _viewModel.StreamInfoViewModel = null;
            _viewModel.StatusMessage = null;
            _viewModel.IsReady = false;
        }
    }
}
