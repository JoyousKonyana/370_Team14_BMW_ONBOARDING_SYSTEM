using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.ViewModel
{
    public class PushNotificationViewModel
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public string SendersMail { get; set; }

        public string ReceiversMail { get; set; }
    }
}
