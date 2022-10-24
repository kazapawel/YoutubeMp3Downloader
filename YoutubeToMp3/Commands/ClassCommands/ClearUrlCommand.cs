using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
