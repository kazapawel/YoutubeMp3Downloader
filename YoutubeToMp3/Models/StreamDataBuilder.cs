using System.Linq;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YoutubeToMp3
{
    public class StreamDataBuilder
    {
        /// <summary>
        /// Returns new StreamData object.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<StreamData> GetStreamData(string url)
        {
            var client = new YoutubeClient();

            // this should probably be in try/catch

            // Metadata
            var Videos = await client.Videos.GetAsync(url);

            // Streams
            var StreamManifest = await client.Videos.Streams.GetManifestAsync(url);

            var muxedHD = StreamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
            var videoHD = StreamManifest.GetVideoOnlyStreams().GetWithHighestVideoQuality();
            var audioHD = StreamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

            // StreamData to return
            var info = new StreamData
            {
                Title = Videos?.Title,
                Author = Videos?.Author.ToString(),
                Duration = Videos?.Duration,
                UploadDate = Videos?.UploadDate,
                Thumbnail = Videos?.Thumbnails.OrderBy(x => x.Resolution.Area).FirstOrDefault().Url,
                AudioHD = audioHD,
                VideoHD = videoHD,
                MuxedHD = muxedHD,
            };

            return info;
        }
    }
}
