using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace YoutubeToMp3
{
    public static class DownloadDataBuilder
    {
        public static DownloadData GetDownloadData(StreamData streamData)
        {
            // Removes problematic characters from stream's title
            var title = FixTitle(streamData.Title);

            // Gets path for downloading
            var downloadPath = GetDownloadPath();

            // Gets directory containing ffmpeg.exe
            var ffmpegPath = GetFFmpegPath();

            return new DownloadData
            {
                FixedTitle = title,
                DownloadPath = downloadPath,
                FfmpegPath = ffmpegPath,
                VideoHD = streamData.VideoHD,
                AudioHD = streamData.AudioHD
            };
        }

        /// <summary>
        /// Replaces all problematic characters with '-'.
        /// </summary>
        private static string FixTitle(string title)
        {
            // Collection of problematic characters
            var problems = new HashSet<char>
            {
                '/','?',':','#','%','&','{','}','<','>','*','$','!','@','+','`','|','=','"'
            };

            return string.Concat(title.Select(x => problems.Contains(x) ? '_' : x));
        }

        /// <summary>
        /// Returns current user desktop path.
        /// </summary>
        /// <returns></returns>
        private static string GetDownloadPath()
        {
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        /// <summary>
        /// Returns path to current working directory.
        /// </summary>
        /// <returns></returns>
        private static string GetFFmpegPath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "ffmpeg.exe");
        }
    }
}
