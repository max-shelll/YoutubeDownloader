namespace YoutubeDownloader
{
    class Sender
    {
        ICommand _icommand;

        public void SetCommand(ICommand command)
        {
            _icommand = command;
        }

        public void Download(string videoUrl, string outputFilePath)
        {
            _icommand.DownloadAsync(videoUrl, outputFilePath);
        }

        public void GetDescription(string videoUrl)
        {
            _icommand.GetDescription(videoUrl);
        }
    }
}
