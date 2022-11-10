using System;

namespace YoutubeToMp3
{
    public class FfmpegFileException : Exception
    {
        public FfmpegFileException()
        {
        }

        public FfmpegFileException(string message)
            : base(message)
        {
        }

        public FfmpegFileException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
