using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.ViewModel
{
    public class ActiveLogViewModel
    {
        public int ActiveLogId { get; set; }
      
        public int UserId { get; set; }
       
        public string ActiveLogDeviceIpaddress { get; set; }
     
        public DateTime ActiveLogLoginTimestamp { get; set; }
        public DateTime ActiveLogLastActiveTimestamp { get; set; }
    }
}
