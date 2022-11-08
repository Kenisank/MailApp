using MailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailSender _mailSender;

        public MailController(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        [HttpPost]
        [Route("new_notification")]
        public async Task<string> Post([FromForm] MessageDto msg)
        { var c = "\"";
          
            var v2 = msg.Content.Replace(c, "");
            var file = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();

            var message = new Message(msg.To, msg.Subject, v2, null);
            await _mailSender.SendMailAsync(message);

            return "Sent";


        }



        [HttpPost]
        [Route("new_notificationn")]
        public async Task<string> Postt()
        {


            //  var message = new Message(msg.To, msg.Subject, msg.Content, null);
            //await _mailSender.SendMailAsync(message);

            return "Sent";


        }
    }
}
