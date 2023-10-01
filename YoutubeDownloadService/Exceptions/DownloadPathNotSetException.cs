namespace YoutubeDownloadService.Exceptions
{
    internal class DownloadPathNotSetException : Exception
    {
        public DownloadPathNotSetException(string message = "Download path not set.")
            : base(message)
        {
        }

        public DownloadPathNotSetException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
