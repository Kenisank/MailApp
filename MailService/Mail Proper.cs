using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailService
{
    public class Mail_Proper
    {
        public string Customer { get; set; }
        public string Project { get; set; }
        public  IFormFileCollection Attachment { get; set; }
        public string Description { get; set; }
}

}
