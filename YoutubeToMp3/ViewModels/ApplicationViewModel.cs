using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeToMp3
{
    public class ApplicationViewModel : BaseViewModel
    {
        public MainViewModel MainViewModel { get; set; }

        public ApplicationViewModel()
        {
            MainViewModel = new MainViewModel();
        }
    }
}
