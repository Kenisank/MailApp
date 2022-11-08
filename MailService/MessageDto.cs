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
            var bodyBuilder = new BodyBuilder { HtmlBody = String.Format("<h2 style='color:green'>{0}</h2>", Content) };

            To = new List<string>();

        }
    }
}
