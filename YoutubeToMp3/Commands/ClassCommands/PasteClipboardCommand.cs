using System.Windows;

namespace YoutubeToMp3
{
    public class PasteClipboardCommand: CommandBase
    {
        private MainViewModel _viewModel;

        public PasteClipboardCommand(MainViewModel vm)
        {
            _viewModel = vm;
        }
        public override void Execute(object parameter)
        {
            _viewModel.Url = Clipboard.GetText();
        }
    }
}
