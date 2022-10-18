using Microsoft.AspNetCore.Http;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailService
{
    public class MessageDto
    {
        public IEnumerable<string> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
       

        public MessageDto()
        {
            To=new List<string>();

        }
    }
}
