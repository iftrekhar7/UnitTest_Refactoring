using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class HouseKeeperServiceTests
    {

        private HouseKeeperService _service;
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IStatementGenerator> _statementGenerator;
        private Mock<IEmailSender> _emailSender;
        private Mock<IXtraMessageBox> _messageBox;
        private DateTime _stamentDate = new DateTime(2017, 1, 1);
        private Housekeeper _housekeepers;
        private string _statemantFileName;

        [SetUp]
        public void SetUp()
        {
            _housekeepers = new Housekeeper { Email = "a", Oid = 1, FullName = "b", StatementEmailBody = "c" };

            _statemantFileName = "FileName";
            _statementGenerator = new Mock<IStatementGenerator>();
            _statementGenerator
               .Setup(sg => sg.SaveStatement(_housekeepers.Oid, _housekeepers.FullName, _stamentDate))
               .Returns(() => _statemantFileName);

            _unitOfWork = new Mock<IUnitOfWork>();
            _emailSender = new Mock<IEmailSender>();
            _messageBox = new Mock<IXtraMessageBox>();
            
            _unitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                _housekeepers
            }.AsQueryable());

            _service = new HouseKeeperService(_unitOfWork.Object, _statementGenerator.Object, _emailSender.Object, _messageBox.Object);

        }



        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStatement()
        {
            _service.SendStatementEmails(_stamentDate);
            _statementGenerator.Verify(sg =>
            sg.SaveStatement(_housekeepers.Oid, _housekeepers.FullName, _stamentDate));
        }
        
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_HouseKeeperEmailIsNullOrEmptySringOrWhiteSpace_ShouldNotGenerateStatement(string houskeeperEmail)
        {
            _housekeepers.Email = houskeeperEmail;

            _service.SendStatementEmails(_stamentDate);
            _statementGenerator.Verify(sg => 
                               sg.SaveStatement(_housekeepers.Oid, _housekeepers.FullName, _stamentDate),
            Times.Never);
        }

        [Test]
        public void SendStatementEmails_WhenCalled_EmailTheStatement()
        {
            _service.SendStatementEmails(_stamentDate);
            VerifyEmailSend();
        }
        
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_FileNameIsNullOrEmptySringOrWhiteSpace_ShouldNotEmailTheStatement(string satementFileName)
        {
            _statemantFileName = satementFileName;

            _service.SendStatementEmails(_stamentDate);

            VerifyEmailNotSend();
        }

        [Test]
        public void SendStatementEmails_EmailSendingFail_DisplayMessageBox()
        {
            VerifyMessageBoxShowing();

            _service.SendStatementEmails(_stamentDate);

            _messageBox.Verify(mb => mb.Show(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButtons.OK));
        }

        private void VerifyMessageBoxShowing()
        {
            _emailSender.Setup(es => es.EmailFile(
               It.IsAny<string>(),
               It.IsAny<string>(),
               It.IsAny<string>(),
               It.IsAny<string>()
               )).Throws<Exception>();
        }

        private void VerifyEmailNotSend()
        {
            _emailSender.Verify(es => es.EmailFile(
               It.IsAny<string>(),
               It.IsAny<string>(),
               It.IsAny<string>(),
               It.IsAny<string>()),
               Times.Never);
        }

        private void VerifyEmailSend()
        {
            _emailSender.Verify(es => es.EmailFile(
                _housekeepers.Email,
                _housekeepers.StatementEmailBody,
                _statemantFileName,
                It.IsAny<string>()
                ));
        }
    }
}
