using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class QueryStatus
    {
        [Key]
        [Column("EquipmentQueryStatusID")]
        public int EquipmentQueryStatusId { get; set; }
        [StringLength(50)]
        public string EquipmentQueryDescription { get; set; }
    }
}
