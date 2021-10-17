using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            OnboarderEquipment = new HashSet<OnboarderEquipment>();
        }

        [Key]
        [Column("EquipmentID")]
        public int EquipmentId { get; set; }
        [Column("EquipmentTypeID")]
        public int? EquipmentTypeId { get; set; }
        [InverseProperty("Equipment")]
        public virtual EquipmentType EquipmentType { get; set; }
        public int? EquipmentTradeInStatus { get; set; }
        [Column("EquipmentBrandID")]
        public int? EquipmentBrandId { get; set; }
        [InverseProperty("Equipment")]
        public virtual EquipmentBrand EquipmentBrand { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EquipmentTradeUnDeadline { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? EquipmentSerialNumber { get; set; }

        [InverseProperty("Equipment")]
        public virtual ICollection<OnboarderEquipment> OnboarderEquipment { get; set; }
    }
}
