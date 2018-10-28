using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamental
{
    [TestFixture]
    public class ErrorLoggerTest
    {
        private ErrorLogger _errorLogger;

        [SetUp]
        public void SetUp()
        {
            _errorLogger = new ErrorLogger();
        }

        [Test]
        public void Log_WhenCalled_SetTheLastErrorPropert()
        {
             _errorLogger.Log("new error 420");

            Assert.That(_errorLogger.LastError, Is.EqualTo("new error 420"));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            Assert.That(() => _errorLogger.Log(error), Throws.ArgumentNullException);
        }


        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var id = Guid.Empty;
            _errorLogger.ErrorLogged += (sender, args) => { id = args; };
            _errorLogger.Log("new error 420");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }

        
    }
}
