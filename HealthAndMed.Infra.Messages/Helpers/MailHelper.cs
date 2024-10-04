using HealthAndMed.Infra.Messages.Settings;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System;

namespace HealthAndMed.Infra.Messages.Helpers
{
    public static class MailHelper
    {
        public static void SendMail(string to, string subject, string body)
        {
            #region Criando a mensagem

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("HealthAndMed", MailSettings.Account));
            message.To.Add(new MailboxAddress("Medico",to));
            message.Subject = subject;

            // Definindo o corpo como HTML
            message.Body = new TextPart("html")
            {
                Text = body
            };

            #endregion

            #region Enviando a mensagem

            using (var smtpClient = new SmtpClient())
            {
                try
                {
                    // Conectar ao servidor SMTP com SSL habilitado
                    smtpClient.Connect(MailSettings.Smtp, MailSettings.Port.Value, SecureSocketOptions.StartTls);

                    // Autenticação com o servidor
                    smtpClient.Authenticate(MailSettings.Account, MailSettings.Password);

                    // Enviar e-mail
                    smtpClient.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
                }
                finally
                {
                    // Desconectar e limpar recursos
                    smtpClient.Disconnect(true);
                }
            }

            #endregion
        }
    }
}
