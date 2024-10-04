using HealthAndMed.Infra.Messages.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Infra.Messages.Helpers
{
    public class MailHelper
    {
        public static void SendMail(string to, string subject, string body)
        {
            #region Criando a mensagem

            var mailMessage = new MailMessage(MailSettings.Account, to);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;

            #endregion

            #region Enviando a mensagem

            var smtpClient = new SmtpClient(MailSettings.Smtp, MailSettings.Port.Value);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(MailSettings.Account, MailSettings.Password);
           // smtpClient.Send(mailMessage);

            #endregion
        }

    }
}
