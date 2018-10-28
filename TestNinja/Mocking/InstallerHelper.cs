using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private IFileDownloader _fileDownloader;
        private string _setupDestinationFile = null;

        public InstallerHelper(IFileDownloader fileDownloader)
        {
            _fileDownloader = fileDownloader;
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _fileDownloader.DownLoadFile(
                     string.Format($"http:/fdsfs.com/{customerName},{installerName}" ),
                     _setupDestinationFile);
                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }

        
    }
}