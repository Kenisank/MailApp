//using MailService;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace EmailApp.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class WeatherForecastController : ControllerBase
//    {
//        private static readonly string[] Summaries = new[]
//        {
//            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//        };

//        private readonly IMailSender _mailSender;

//        public WeatherForecastController(IMailSender mailSender)
//        {
//            _mailSender = mailSender;
//        }

//        //[HttpGet]
//        //public async Task<IEnumerable<WeatherForecast>> Get()
//        //{
//        //    var rng = new Random();

//        //    var message = new Message(new string[] { "wilberforce@leptonsmulticoncept.com.ng", "chideraduru51@gmail.com", "kenisank1@gmail.com" }, "Test email async ", "Welcome to WilberForce Company Ltd.", null);
//        //    await _mailSender.SendMailAsync(message);

//        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//        //    {
//        //        Date = DateTime.Now.AddDays(index),
//        //        TemperatureC = rng.Next(-20, 55),
//        //        Summary = Summaries[rng.Next(Summaries.Length)]
//        //    })
//        //    .ToArray();
//        //}



//        [HttpPost]
//        [Route("send_notification")]
//        public async Task<string> Post(MessageDto msg)
//        {
//            var rng = new Random();

//            var message = new Message(msg.To, msg.Subject, msg.Content, null);
//            await _mailSender.SendMailAsync(message);

//            return "Sent";


//        }
//    }
//}
