using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailService
{
    public class MailSender : IMailSender
    {
        private readonly MailConfig _config;

        public MailSender(MailConfig config)
        {
            _config = config;
        }

        public void SendMail(Message message)
        {
            var mailMsg = CreateMailMessage(message);
            Send(mailMsg);
        }


        private MimeMessage CreateMailMessage(Message message)
        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress(_config.From));
            mailMessage.To.AddRange(message.To);
            mailMessage.Subject = message.Subject;
            mailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };



            return mailMessage;
        }



        private void Send(MimeMessage mailMessage)
        {

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_config.SmtpServer, _config.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.AuthenticationMechanisms.Remove("XOAUTH");
                    client.AuthenticationMechanisms.Remove("OAUTHBEARER");                 
                    client.Authenticate(_config.UserName, _config.Password);

                    client.Send(mailMessage);
                }
                catch
                {

                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }

        }
    }
}
