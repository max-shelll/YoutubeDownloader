namespace YoutubeDownloader
{
    interface ICommand
    {
        public void DownloadAsync(string videoUrl, string outputFilePath);
        public void GetDescription(string videoUrl);
    }
}
