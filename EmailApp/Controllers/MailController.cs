using MailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<string> Post(MessageDto msg)
        {
          

            var message = new Message(msg.To, msg.Subject, msg.Content, null);
            await _mailSender.SendMailAsync(message);

            return "Sent";


        }
    }
}
