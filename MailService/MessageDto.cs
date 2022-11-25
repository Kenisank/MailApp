using Microsoft.AspNetCore.Http;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailService
{
    public class MessageDto
    {
        public PersonDetailsDto To { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }
       

        public MessageDto()
        {
            var bodyBuilder = new BodyBuilder { HtmlBody = String.Format("<div>{0}</div>", Content) };

            To = new PersonDetailsDto();

        }
    }
}
