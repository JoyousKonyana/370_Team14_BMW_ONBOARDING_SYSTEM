using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class EquipmentQuery
    {
        public EquipmentQuery()
        {
            EquipmentQueryStatus = new HashSet<EquipmentQueryStatus>();
        }

        [Key]
        [Column("EquipmentQueryID")]
        public int EquipmentQueryId { get; set; }
        [Column("EquipmentID")]
        public int? EquipmentId { get; set; }
        [Column("OnboarderID")]
        public int? OnboarderId { get; set; }
        public string EquipmentQueryDescription { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EquipmentQueryDate { get; set; }

        [ForeignKey(nameof(EquipmentId))]
        [InverseProperty(nameof(OnboarderEquipment.EquipmentQuery))]
        public virtual OnboarderEquipment Equipment { get; set; }
        [InverseProperty("EquipmentQuery")]
        public virtual ICollection<EquipmentQueryStatus> EquipmentQueryStatus { get; set; }
    }
}
