using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class OnboarderEquipment
    {
        public OnboarderEquipment()
        {
            EquipmentQuery = new HashSet<EquipmentQuery>();
        }

        [Key]
        [Column("EquipmentID")]
        public int EquipmentId { get; set; }
        [Column("OnboarderID")]
        public int OnboarderId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EquipmentCheckOutDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EquipmentCheckInDate { get; set; }
        [StringLength(50)]
        public string EquipmentCheckInCondition { get; set; }

        [ForeignKey(nameof(EquipmentId))]
        [InverseProperty("OnboarderEquipment")]
        public virtual Equipment Equipment { get; set; }
        [ForeignKey(nameof(OnboarderId))]
        [InverseProperty("OnboarderEquipment")]
        public virtual Onboarder Onboarder { get; set; }
        [InverseProperty("Equipment")]
        public virtual ICollection<EquipmentQuery> EquipmentQuery { get; set; }
    }
}
