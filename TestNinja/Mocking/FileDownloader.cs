using System.Net;

namespace TestNinja.Mocking
{
    public class FileDownloader : IFileDownloader
    {
        public void DownLoadFile(string url, string path)
        {
            var client = new WebClient();
            client.DownloadFile(url, path);
            
        }
    }
}
