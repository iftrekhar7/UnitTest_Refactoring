using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace TestNinja.Mocking
{
    public class HouseKeeperService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatementGenerator _statementGenerator;
        private readonly IEmailSender _emailSender;
        private readonly IXtraMessageBox _messageBox;

        public HouseKeeperService(
            IUnitOfWork unitOfWork, 
            IStatementGenerator statementGenerator,
            IEmailSender emailSender,
            IXtraMessageBox messageBox)
            {
                _unitOfWork = unitOfWork;
                _statementGenerator = statementGenerator;
                _emailSender = emailSender;
                _messageBox = messageBox;
            }
        
        public void SendStatementEmails(DateTime statementDate)
        {
            var housekeepers = _unitOfWork.Query<Housekeeper>();

            foreach (var housekeeper in housekeepers)
            {
                if (string.IsNullOrWhiteSpace(housekeeper.Email)) 
                    continue;

                var statementFilename = _statementGenerator.SaveStatement(housekeeper.Oid, housekeeper.FullName, statementDate);

                if (string.IsNullOrWhiteSpace(statementFilename))
                    continue;

                var emailAddress = housekeeper.Email;
                var emailBody = housekeeper.StatementEmailBody;

                try
                {
                    _emailSender.EmailFile(emailAddress, emailBody, statementFilename,
                        string.Format("Sandpiper Statement {0:yyyy-MM} {1}", statementDate, housekeeper.FullName));
                }
                catch (Exception e)
                {
                    _messageBox.Show(e.Message, string.Format("Email failure: {0}", emailAddress),
                        MessageBoxButtons.OK);
                }
            }
        }
    }

    public enum MessageBoxButtons
    {
        OK
    }

    public interface IXtraMessageBox
    {
        void Show(string s, string housekeeperStatements, MessageBoxButtons ok);
    }

    public class XtraMessageBox : IXtraMessageBox
    {
        public void Show(string s, string housekeeperStatements, MessageBoxButtons ok)
        {
        }
    }

    public class MainForm
    {
        public bool HousekeeperStatementsSending { get; set; }
    }

    public class DateForm
    {
        public DateForm(string statementDate, object endOfLastMonth)
        {
        }

        public DateTime Date { get; set; }

        public DialogResult ShowDialog()
        {
            return DialogResult.Abort;
        }
    }

    public enum DialogResult
    {
        Abort,
        OK
    }
}