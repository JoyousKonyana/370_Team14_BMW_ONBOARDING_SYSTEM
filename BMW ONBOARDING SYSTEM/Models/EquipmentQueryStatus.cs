using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    [Table("EquipmentQueryStatus.")]
    public partial class EquipmentQueryStatus
    {
        [Key]
        [Column("EquipmentQueryStatusID")]
        public int EquipmentQueryStatusId { get; set; }
        [Column("EquipmentQueryID")]
        public int? EquipmentQueryId { get; set; }
    }
}
