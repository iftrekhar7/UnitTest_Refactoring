using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTest
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _helper;

        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _helper = new InstallerHelper(_fileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_DownloadComplete_ReturnTrue()
        {
            var result = _helper.DownloadInstaller("Customer", "Installer");
            Assert.That(result, Is.True);
        }

        [Test]
        public void DownloadInstaller_DownloadFail_ReturnFalse()
        {
            _fileDownloader.Setup(fd => 
            fd.DownLoadFile(It.IsAny<string>(), It.IsAny<string>()))
            .Throws<WebException>();
            var result = _helper.DownloadInstaller("Customer", "Installer");
            Assert.That(result, Is.False);
        }
    }
}
