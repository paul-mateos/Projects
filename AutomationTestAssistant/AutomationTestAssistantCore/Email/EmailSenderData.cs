using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomationTestAssistantCore
{
    public class EmailSenderData
    {
        public string SmtpClient { get; set; }
        public List<string> Emails { get; set; }
        public string FromEmail { get; set; }
        public string EmailBody { get; set; }
        public string Subject { get; set; }
        public List<string> AttachmentPath { get; set; }

        public EmailSenderData(string smtpClient, List<string> emails, string fromEmail,
            string emailBody, string subject, List<string> attachmentPath)
        {
            this.SmtpClient = smtpClient;
            this.Emails = emails;
            this.FromEmail = fromEmail;
            this.EmailBody = emailBody;
            this.Subject = subject;
            this.AttachmentPath = attachmentPath;
        }

        public EmailSenderData(string smtpClient, List<string> emails,
            string fromEmail, string emailBody, string subject)
        {
            this.SmtpClient = smtpClient;
            this.Emails = emails;
            this.FromEmail = fromEmail;
            this.EmailBody = emailBody;
            this.Subject = subject;
            this.AttachmentPath = null;
        }

        public static string GenerateSubject(string prefix)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(prefix);
            sb.Append(" ");
            sb.Append(DateTime.Now.ToLongDateString());
            string emailSubject = sb.ToString();

            return emailSubject;
        }
    }
}
