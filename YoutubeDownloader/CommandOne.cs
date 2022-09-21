using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YoutubeDownloader
{
    class CommandOne : ICommand
    {
        Receiver receiver;
        YoutubeClient client = new YoutubeClient();

        public CommandOne(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public async void DownloadAsync(string videoUrl, string outputFilePath)
        {
            receiver.Operation();

            try
            {
                var video = client.Videos.GetAsync(videoUrl);

                var streamManifest = client.Videos.Streams.GetManifestAsync(video.Result.Id);
                var streamInfo = streamManifest.Result.GetMuxedStreams().GetWithHighestVideoQuality();

                await client.Videos.Streams.DownloadAsync(streamInfo, $"{outputFilePath}/{video.Result.Title}.{streamInfo.Container}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async void GetDescription(string videoUrl)
        {
            receiver.Operation();

            var video = await client.Videos.GetAsync(videoUrl);

            Console.WriteLine($"\nОписание видео:\n{video.Description}");
        }
    }
}
