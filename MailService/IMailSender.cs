using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MailService
{
    public interface IMailSender
    {
        void SendMail (Message message);
        Task SendMailAsync(Message message);
    }
}
