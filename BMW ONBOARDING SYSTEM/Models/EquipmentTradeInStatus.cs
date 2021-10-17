using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class EquipmentTradeInStatus
    {
        [Key]
        [Column("EquipmentTradeInStatusID")]
        public int EquipmentTradeInStatusId { get; set; }
        [StringLength(50)]
        public string EquipmentTradeInStatusDescription { get; set; }
    }
}
