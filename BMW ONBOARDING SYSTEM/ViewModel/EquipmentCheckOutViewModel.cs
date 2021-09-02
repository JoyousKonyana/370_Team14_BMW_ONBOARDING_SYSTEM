using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.ViewModel
{
    public class EquipmentCheckOutViewModel
    {
        public int EquipmentId { get; set; }
        public int OnboarderId { get; set; }
        public DateTime EquipmentCheckOutDate { get; set; }

        public string EquipmentCheckOutCondition { get; set; }
    }
}
