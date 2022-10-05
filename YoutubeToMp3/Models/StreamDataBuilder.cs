using System.Threading.Tasks;
using YoutubeExplode;

namespace YoutubeToMp3
{
    public class StreamDataBuilder
    {
        public async Task<StreamData> GetStreamData(string url)
        {
            var client = new YoutubeClient();
            var info = new StreamData();
            info.Videos = await client.Videos.GetAsync(url);
            info.StreamManifest = await client.Videos.Streams.GetManifestAsync(url);
            return info;
        }
    }
}
