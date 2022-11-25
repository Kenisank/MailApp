using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailService
{
    public class PersonDetailsDto
    {
        public List<string> Name { get; set; }
        public List<string> To { get; set; }
    }
}
