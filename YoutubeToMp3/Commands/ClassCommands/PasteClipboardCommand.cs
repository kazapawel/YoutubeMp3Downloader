using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
