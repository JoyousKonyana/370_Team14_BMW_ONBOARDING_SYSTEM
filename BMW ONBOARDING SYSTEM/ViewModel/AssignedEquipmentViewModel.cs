using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.ViewModel
{
    public class AssignedEquipmentViewModel
    {
        public int EquipmentId { get; set; }
        public int OnboarderId { get; set; }
        public DateTime EquipmentCheckOutDate { get; set; }
      
        public string EquipmentCheckOutCondition { get; set; }
      
        public DateTime EquipmentCheckInDate { get; set; }
 
        public string EquipmentCheckInCondition { get; set; }
    }
}
