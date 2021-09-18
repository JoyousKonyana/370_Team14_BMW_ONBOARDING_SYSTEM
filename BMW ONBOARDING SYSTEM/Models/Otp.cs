using System;
using System.Collections.Generic;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class Otp
    {
        public int OtpId { get; set; }
        public int UserId { get; set; }
        public string OtpValue { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
