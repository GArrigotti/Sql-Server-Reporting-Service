using Report_Downloader.Model;
using System.Net;
using System.Net.Mail;

namespace Report_Downloader.Helper
{
    public static class Mailer
    {
        public static void SendEmail(string message)
        {
            var email = new EmailModel(message);
            var smtp = new SmtpServerModel();

            using (var smtpHost = new SmtpClient(smtp.SmtpHost, smtp.SmtpPort))
            {
                smtpHost.Credentials = new NetworkCredential(smtp.SmtpUsername, smtp.SmtpPassword);
                var emailToDeliver = new MailMessage(email.From, email.To, email.Subject, email.Message);
                smtpHost.Send(emailToDeliver);
            }
        }
    }
}
