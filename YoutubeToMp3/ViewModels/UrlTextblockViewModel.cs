using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YoutubeToMp3
{
    public class UrlTextblockViewModel : BaseViewModel
    {
        public string Url { get; set; }
        public ICommand TextChangedCommand { get; set; }

        public UrlTextblockViewModel()
        {
        }
    }
}
