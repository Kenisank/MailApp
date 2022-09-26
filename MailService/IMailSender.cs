using System;
using System.Collections.Generic;
using System.Text;

namespace MailService
{
    public interface IMailSender
    {
        void SendMail (Message message);

    }
}
