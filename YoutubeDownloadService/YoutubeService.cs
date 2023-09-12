using YoutubeExplode;

namespace YoutubeDownloadService
{
    public class YoutubeService
    {
        /// <summary>
        /// Gets information related to youtube stream on given url.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<StreamInfo> GetStreamInfo(string url)
        {
            var client = new YoutubeClient();

            // Metadata
            var Videos = await client.Videos.GetAsync(url);

            // Streams
            var StreamManifest = await client.Videos.Streams.GetManifestAsync(url);

            // Gets the 1080p video 
            var videoHD = StreamManifest.GetVideoOnlyStreams().FirstOrDefault(x => x.VideoQuality.Label.Contains("1080"));

            // StreamData to return
            var info = new StreamInfo
            {
                Title = Videos?.Title,
                Author = Videos?.Author.ToString(),
                Duration = Videos?.Duration,
                UploadDate = Videos?.UploadDate,
                Thumbnail = Videos?.Thumbnails.OrderBy(x => x.Resolution.Area).FirstOrDefault().Url,
                //AudioHD = StreamManifest.GetAudioOnlyStreams().GetWithHighestBitrate(),
                //VideoHD = videoHD ?? StreamManifest.GetVideoOnlyStreams().GetWithHighestVideoQuality(),
                //MuxedHD = StreamManifest.GetMuxedStreams().GetWithHighestVideoQuality(),
            };
            return info;
        }


    }
}
