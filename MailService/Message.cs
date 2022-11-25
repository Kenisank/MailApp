using Microsoft.AspNetCore.Http;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MailService
{
    public class Message
    {

        
        public MailboxAddress To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public IFormFileCollection Attachements { get; set; }

          public Message(string to, string subject, string content,IFormFileCollection attachements)
        {
            // To = new List<MailboxAddress>();

            To = (new MailboxAddress(to));
            Subject = subject;
            Content = content;
            Attachements = attachements;
        }

        public Message(string[] vs, string v1, string v2)
        {
        }
    }
}
