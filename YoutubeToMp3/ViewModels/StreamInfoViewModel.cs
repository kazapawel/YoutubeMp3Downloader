using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeToMp3
{
    public class StreamInfoViewModel : BaseViewModel
    {
        private readonly StreamData _model;

        public StreamInfoViewModel(StreamData model)
        {
            _model = model;
        }
    }
}
