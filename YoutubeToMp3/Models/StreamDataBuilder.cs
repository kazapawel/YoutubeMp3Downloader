using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

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
