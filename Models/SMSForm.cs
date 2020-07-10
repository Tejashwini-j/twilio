using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SendSMSUsingTwilioAPI.Models
{
    public class SMSForm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Number { get; set; }
    }
}