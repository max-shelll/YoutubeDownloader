namespace YoutubeDownloader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sender = new Sender();

            var receiver = new Receiver();

            var commandOne = new CommandOne(receiver);

            sender.SetCommand(commandOne);

            string videoUrl = "https://www.youtube.com/watch?v=fKN6P6xzbPc";
            string outputFilePath = Directory.GetCurrentDirectory();

            sender.GetDescription(videoUrl);
            sender.Download(videoUrl, outputFilePath);
        }
    }
}