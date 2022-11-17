using System;

namespace YoutubeToMp3
{
    public class FFmpegNotFoundException : Exception
    {
        public FFmpegNotFoundException(string message = "Ffmmpeg.exe not found.")
            : base(message)
        {
        }

        public FFmpegNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
