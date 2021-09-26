using BMW_ONBOARDING_SYSTEM.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.AspNet.Core;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace BMW_ONBOARDING_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : TwilioController
    {
        private readonly ILogger<SmsController> _logger;
        public SmsController(ILogger<SmsController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index()
        //{
        //    SendSMS("+17067863614", "+918800______", "Hey there! this is a test message from Twilio.");
        //    return Ok();
        //}        //public IActionResult Index()
        //{
        //    SendSMS("+17067863614", "+918800______", "Hey there! this is a test message from Twilio.");
        //    return Ok();
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return Ok(new  { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult SendSMS(string v, [FromBody] SendSmsViewModel model)
        {
            var accountSid = "AC6b52cdb391ab892a1041457ee9056576";
            var authToken = "b6e67eb41687722514f792a55ce4f5c4";

         
            TwilioClient.Init(accountSid, authToken);
            var to = new PhoneNumber("+27785622125");
            var from = new PhoneNumber("+17254448788");
            var message = "Dear onboarder Please check your email we have provided you with all the neccessary details looking forward to working with you";
            try
            {
                MessageResource response = MessageResource.Create(
                    body: message,
                    from:from,
                    to: to
                );
                return Ok("Message send successfull");
            }
            catch (Exception ex)
            {
               BadRequest();
            }

            return BadRequest();
        }
    }
}

