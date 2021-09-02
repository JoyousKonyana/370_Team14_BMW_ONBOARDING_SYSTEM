using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.ViewModel
{
    public class WarrantyViewModel
    {
        public int WarrantyId { get; set; }
      
        public DateTime WarrantyStartDate { get; set; }
       
        public DateTime WarrantyEndDate { get; set; }
     
        public string WarrantyStatus { get; set; }
    }
}
