using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDownloadService.Exceptions
{
    public class VideoUrlNullException : Exception
    {
        public VideoUrlNullException(string message = "Video url is null or empty string.")
           : base(message)
        {
        }

        public VideoUrlNullException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
