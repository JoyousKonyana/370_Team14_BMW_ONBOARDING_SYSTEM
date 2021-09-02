using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.ViewModel
{
    public class CreateAuditLogViewModel
    {
        public int UserId { get; set; }
     
        public DateTime AuditLogDatestamp { get; set; }
        public DateTime AuditLogTimestamp { get; set; }
      
        public string AuditLogDescription { get; set; }
    }
}
