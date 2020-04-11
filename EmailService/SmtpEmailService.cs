using System;
using System.Net;
using System.Net.Mail;

namespace EmailService
{
    public class SmtpEmailService
    {
        SmtpClient smtpServer;
        string _username;

        public SmtpEmailService(string smtpHost, string username, string password)
        {
            smtpServer = new SmtpClient(smtpHost);
            smtpServer.Port = 25;
            smtpServer.Credentials = new NetworkCredential(username, password);
            _username = username;
        }

        public void SendEmail(string body, string subject, string[] recipients)
        {
            MailMessage mail = new MailMessage()
            {
                Body = body,
                Subject = subject,
                IsBodyHtml = true
            };

            foreach (var recipient in recipients)
            {
                mail.To.Add(recipient);
            }

            mail.From = new MailAddress(_username, "Jim");

            smtpServer.Send(mail);
        }
    }
}
