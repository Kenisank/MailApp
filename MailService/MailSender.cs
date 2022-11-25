using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailService
{
    public class MailSender : IMailSender
    {
        private readonly MailConfig _config;
        private Microsoft.AspNetCore.Http.IFormFile attachment;

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
            mailMessage.To.Add(message.To);
            mailMessage.Subject = message.Subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = String.Format("<div>{0}</div>", message.Content) };

            if (message.Attachements != null && message.Attachements.Any())
            {
                byte[] fileBytes;
                foreach(var attachement in message.Attachements)
                {
                   using(var ms= new MemoryStream())
                    {
                        attachment = CopyTo(ms);
                        fileBytes= ms.ToArray();
                    }
                    bodyBuilder.Attachments.Add(attachement.FileName, fileBytes, ContentType.Parse(attachement.ContentType));
                }
            }

            mailMessage.Body = bodyBuilder.ToMessageBody();
            return mailMessage;
        }

        private Microsoft.AspNetCore.Http.IFormFile CopyTo(MemoryStream ms)
        {
            throw new NotImplementedException();
        }

        public async  Task SendMailAsync(Message message)
        {
            var mailMessage = CreateMailMessage(message);
            await SendAsync(mailMessage);
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

        } private async Task SendAsync(MimeMessage mailmessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                   await client.ConnectAsync(_config.SmtpServer, _config.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.AuthenticationMechanisms.Remove("XOAUTH");
                    client.AuthenticationMechanisms.Remove("OAUTHBEARER");
                   await client.AuthenticateAsync(_config.UserName, _config.Password);

                    await  client.SendAsync(mailmessage);
                }
                catch
                {

                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }


        }
    }
}
