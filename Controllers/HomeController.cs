using SendSMSUsingTwilioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SendSMSUsingTwilioAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SendSMS()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendSMS(SMSForm sms)
        {
            if (ModelState.IsValid)
            {
                // Find your Account Sid and Auth Token at twilio.com/console
                const string accountSid = "ACde99282c6322da86eff002fe91a98b52";
                const string authToken = "d62cf431135173748a79df4e473a27a0";

                TwilioClient.Init(accountSid, authToken);
                
                var to = new PhoneNumber("+91" + sms.Number);

                var message = MessageResource.Create(
                    to,
                    
                    from: new PhoneNumber("+1 205 898 8275"), //  From number, must be an SMS-enabled Twilio number ( This will send sms from ur "To" numbers ). 
                    body: $"Hello " + sms.Name + " !! Welcome to Twilio SMS API example in ASP.NET MVC!!");


                ViewBag.Message = "Message Sent";
                return RedirectToAction("SendSMS");
            }
            else
            {
                return View();
            }
        }
    }
}