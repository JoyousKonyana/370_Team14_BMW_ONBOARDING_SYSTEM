using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.ViewModel
{
    public class EquipmentQueryViewModelcs
    {

       
        public int EquipmentId { get; set; }
        public int? OnboarderId { get; set; }

        public string EquipmentQueryDescription { get; set; }
       
        public DateTime EquipmentQueryDate { get; set; }
    }
}
