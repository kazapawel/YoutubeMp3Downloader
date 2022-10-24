using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeToMp3
{
    public class StreamDataViewModel: BaseViewModel
    {
        private StreamData streamData;

        public string Title => streamData?.Title;
        public string Duration => streamData?.Duration.ToString();
        public string Author => streamData?.Author;
        public string UploadDate => streamData?.UploadDate.ToString();
    }
}
