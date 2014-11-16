using System;
using System.Linq;
using System.Net.Mail;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AutomationTestAssistantCore
{
    public class EmailSender
    {
        private EmailSender() { }

        public static void SendEmail(EmailSenderData emailData)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient(emailData.SmtpClient);
            smtpServer.Port = 25;
            mail.From = new MailAddress(emailData.FromEmail);

            foreach (string currentEmail in emailData.Emails)
            {
                mail.To.Add(currentEmail);
            }
            mail.Subject = emailData.Subject;
            mail.IsBodyHtml = true;
            mail.Body = emailData.EmailBody;

            if (emailData.AttachmentPath != null)
            {                
                foreach (string currentPath in emailData.AttachmentPath)
                {
                    Attachment  attachment = new Attachment(currentPath);
                    mail.Attachments.Add(attachment);                    
                }               
                smtpServer.Send(mail);
                DisposeAllAttachments(mail);
            }
            else
            {
                smtpServer.Send(mail);
            }

            mail.Dispose();
            smtpServer.Dispose();
        }

        private static void DisposeAllAttachments(MailMessage mail)
        {
            foreach (Attachment currentAttachment in mail.Attachments)
            {
                currentAttachment.Dispose();
            }
        }

        public static List<string> ExtractAllEmails(string emailsString)
        {
            List<string> emails = new List<string>();
            foreach (string currentEmail in emailsString.Split(','))
            {
                emails.Add(currentEmail);
            }

            return emails;
        }

        public static bool ValidateEmails(List<string> emails)
        {
            bool isEmailCorrect = true;
            foreach (string currentEmail in emails)
            {
                if (!Regex.IsMatch(currentEmail, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
                {
                    isEmailCorrect = false;
                    break;
                }
            }

            return isEmailCorrect;
        }
    }
}
