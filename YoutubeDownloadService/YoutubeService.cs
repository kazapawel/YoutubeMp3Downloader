using YoutubeDownloadService.Commands;
using YoutubeDownloadService.Exceptions;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos.Streams;

namespace YoutubeDownloadService
{
    public class YoutubeService
    {
        /// <summary>
        /// Cached stream manifest to identify videos.
        /// </summary>
        private static Dictionary<string, StreamManifest> _manifests = new Dictionary<string, StreamManifest>();

        /// <summary>
        /// Gets information related to youtube stream from given url.
        /// </summary>
        public static async Task<StreamInfoDto> GetStreamInfo(GetStreamInfoCommand command)
        {
            var client = new YoutubeClient();

            // metadata
            var videos = await client.Videos.GetAsync(command.Url);

            // manifest
            StreamManifest streamManifest;
            if (_manifests.TryGetValue(command.Url, out StreamManifest? value))
            {
                streamManifest = value;
            }
            else
            {
                streamManifest = await client.Videos.Streams.GetManifestAsync(command.Url);
                _manifests.Add(command.Url, streamManifest);
            }

            // video streams
            IEnumerable<VideoDto> videoStreams;
            if (string.IsNullOrWhiteSpace(command.FfmpegPath))
            {
                videoStreams = streamManifest
                .GetMuxedStreams()
                .OrderByDescending(video => video.VideoQuality.MaxHeight)
                .Select(video => new VideoDto
                {
                    IdUrl = video.Url,
                    Name = video.ToString(),
                    Quality = video.VideoQuality.ToString(),
                    Container = video.Container.ToString(),
                    Size = video.Size.ToString(),
                    Bitrate = video.Bitrate.ToString(),
                    VideoCodec = video.VideoCodec,
                    VideoResolution = video.VideoResolution.ToString(),
                    AudioCodec = video.AudioCodec.ToString(),
                });
            }
            else
            {
                videoStreams = streamManifest
                .GetVideoOnlyStreams()
                .OrderByDescending(video => video.VideoQuality.MaxHeight)
                .Select(video => new VideoDto
                {
                    IdUrl = video.Url,
                    Name = video.ToString(),
                    Quality = video.VideoQuality.ToString(),
                    Container = video.Container.ToString(),
                    Size = video.Size.ToString(),
                    Bitrate = video.Bitrate.ToString(),
                    VideoCodec = video.VideoCodec,
                    VideoResolution = video.VideoResolution.ToString(),
                });
            }

            // best audio
            var audioHd = streamManifest
                .GetAudioOnlyStreams()
                .GetWithHighestBitrate();

            var audioDto = new AudioDto
            {
                Container = audioHd.Container.ToString(),
                Bitrate = audioHd.Bitrate.ToString(),
                Size = audioHd.Size.ToString(),
            };

            var info = new StreamInfoDto
            {
                Title = videos?.Title,
                Author = videos?.Author.ToString(),
                Duration = videos?.Duration,
                UploadDate = videos?.UploadDate,
                Thumbnail = videos?.Thumbnails.OrderBy(x => x.Resolution.Area).FirstOrDefault().Url,
                VideoStreams = videoStreams,
                AudioHd = audioDto,
            };

            return info;
        }

        public static async Task DownloadMuxedStream(DownloadMuxedStreamCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.DownloadPath)) 
                throw new DownloadPathNotSetException();

            if (string.IsNullOrEmpty(command.IdUrl))
                throw new VideoUrlNullException();

            // prepare
            var client = new YoutubeClient();
            var videos = await client.Videos.GetAsync(command.Url);
            var fixedTitle = FixTitle(videos.Title);
            var downloadPath = @$"{command.DownloadPath}\{fixedTitle}.mp4";

            // manifest
            StreamManifest streamManifest;
            if (_manifests.TryGetValue(command.Url, out StreamManifest? value))
            {
                streamManifest = value;
            }
            else
            {
                streamManifest = await client.Videos.Streams.GetManifestAsync(command.Url);
                _manifests.Add(command.Url, streamManifest);
            }

            var muxedStreamInfo = streamManifest
                .GetMuxedStreams()
                .FirstOrDefault(x => x.Url == command.IdUrl); // check for null

            await client.Videos.Streams.DownloadAsync(muxedStreamInfo, downloadPath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="FFmpegNotFoundException"></exception>
        /// <exception cref="DownloadPathNotSetException"></exception>
        public static async Task DownloadVideoAsync(DownloadVideoCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.DownloadPath))
            {
                throw new DownloadPathNotSetException();
            }

            if (string.IsNullOrEmpty(command.IdUrl))
            {
                throw new VideoUrlNullException();
            }

            if (!File.Exists(command.FfmpegPath))
            {
                throw new FFmpegNotFoundException();
            }

            var client = new YoutubeClient();
            var videos = await client.Videos.GetAsync(command.Url);
            var fixedTitle = FixTitle(videos.Title);
            var downloadPath = @$"{command.DownloadPath}\{fixedTitle}.mp4";

            // manifest
            StreamManifest streamManifest;
            if (_manifests.ContainsKey(command.Url))
            {
                streamManifest = _manifests[command.Url];
            }
            else
            {
                streamManifest = await client.Videos.Streams.GetManifestAsync(command.Url);
                _manifests.Add(command.Url, streamManifest);
            }

            // audio with the best quality
            var audioHD = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
            var test = streamManifest
                .GetVideoOnlyStreams();

            //var urls = streamManifest
            //    .GetVideoOnlyStreams()
            //    .Select(x => x.Url);

            // gets stream by id
            var video = streamManifest
                .GetVideoOnlyStreams()
                .FirstOrDefault(x => x.Url == command.IdUrl);

            var infos = new IStreamInfo[]
            {
                audioHD,
                video,
            };

            await client.Videos
                .DownloadAsync(infos, new ConversionRequestBuilder(downloadPath)
                .SetFFmpegPath(command.FfmpegPath)
                .Build());
        }

        /// <summary>
        /// Downloads audio with best quality and saves it as mp3 file.
        /// </summary>
        /// <exception cref="FFmpegNotFoundException"></exception>
        /// <exception cref="DownloadPathNotSetException"></exception>
        public static async Task DownloadAudioAsync(DownloadAudioCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.DownloadPath))
            {
                throw new DownloadPathNotSetException();
            }

            if (!File.Exists(command.FfmpegPath))
            {
                throw new FFmpegNotFoundException();
            }

            var client = new YoutubeClient();
            var videos = await client.Videos.GetAsync(command.Url);
            var fixedTitle = FixTitle(videos.Title);
            var downloadPath = @$"{command.DownloadPath}\{fixedTitle}.mp3";

            // streams
            var streamManifest = await client.Videos.Streams.GetManifestAsync(command.Url);

            // audio with the best quality
            var audioHD = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

            var infos = new IStreamInfo[]
            {
                audioHD,
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
