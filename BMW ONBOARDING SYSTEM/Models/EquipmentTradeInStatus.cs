using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class EquipmentTradeInStatus
    {
        public EquipmentTradeInStatus()
        {
            Equipment = new HashSet<Equipment>();
        }

        [Key]
        [Column("EquipmentTradeInStatusID")]
        public int EquipmentTradeInStatusId { get; set; }
        [StringLength(50)]
        public string EquipmentTradeInStatusDescription { get; set; }

        [InverseProperty("EquipmentTradeInStatusNavigation")]
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
