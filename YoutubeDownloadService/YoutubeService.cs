using AngleSharp.Dom;
using YoutubeDownloadService.Exceptions;
using YoutubeDownloadService.Requests;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos.Streams;

namespace YoutubeDownloadService
{
    public class YoutubeService
    {
        /// <summary>
        /// Gets information related to youtube stream on given url.
        /// </summary>
        /// <param name="url"></param>
        public static async Task<StreamInfoDto> GetStreamInfo(string url)
        {
            var client = new YoutubeClient();

            // Metadata
            var Videos = await client.Videos.GetAsync(url);

            // Streams
            var StreamManifest = await client.Videos.Streams.GetManifestAsync(url);

            // Gets the 1080p video 
            var videoHD = StreamManifest
                .GetVideoOnlyStreams()
                .FirstOrDefault(x => x.VideoQuality.Label.Contains("1080"));

            // StreamData to return
            var info = new StreamInfoDto
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <exception cref="FFmpegNotFoundException"></exception>
        /// <exception cref="DownloadPathNotSetException"></exception>
        public static async Task DownloadVideoAsync(DownloadVideoCommand command)
        {
            if (!File.Exists(command.FfmpegPath))
                throw new FFmpegNotFoundException();

            if (string.IsNullOrWhiteSpace(command.DownloadPath))
                throw new DownloadPathNotSetException();

            var client = new YoutubeClient();

            var videos = await client.Videos.GetAsync(command.Url);
            var fixedTitle = FixTitle(videos.Title);
            var downloadPath = @$"{command.DownloadPath}\{fixedTitle}.mp4";

            // streams
            var streamManifest = await client.Videos.Streams.GetManifestAsync(command.Url);

            // audio with the best quality
            var audioHD = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

            // 1080p video 
            var videoHD = streamManifest
                .GetVideoOnlyStreams()
                .FirstOrDefault(x => x.VideoQuality.Label.Contains("1080"));

            // if there is no 1080p video gets the video with best available quality
            var videoToDownload = videoHD 
                ?? streamManifest.GetVideoOnlyStreams().GetWithHighestVideoQuality();

            var infos = new IStreamInfo[]
            {
                audioHD,
                videoToDownload,
            };

            await client.Videos
                .DownloadAsync(infos, new ConversionRequestBuilder(downloadPath)
                .SetFFmpegPath(command.FfmpegPath)
                .Build());
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
    }
}
