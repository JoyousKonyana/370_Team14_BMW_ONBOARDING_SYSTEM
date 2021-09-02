using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class Equipment
    {
        [Key]
        [Column("EquipmentID")]
        public int EquipmentId { get; set; }
        [Column("EquipmentTypeID")]
        public int? EquipmentTypeId { get; set; }
        public int? EquipmentTradeInStatus { get; set; }
        [Column("WarrantyID")]
        public int? WarrantyId { get; set; }
        [Column("EquipmentBrandID")]
        public int? EquipmentBrandId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EquipmentTradeUnDeadline { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? EquipmentSerialNumber { get; set; }

        [ForeignKey(nameof(EquipmentBrandId))]
        [InverseProperty("Equipment")]
        public virtual EquipmentBrand EquipmentBrand { get; set; }
        [ForeignKey(nameof(EquipmentTradeInStatus))]
        [InverseProperty("Equipment")]
        public virtual EquipmentTradeInStatus EquipmentTradeInStatusNavigation { get; set; }
        [ForeignKey(nameof(EquipmentTypeId))]
        [InverseProperty("Equipment")]
        public virtual EquipmentType EquipmentType { get; set; }
        [ForeignKey(nameof(WarrantyId))]
        [InverseProperty("Equipment")]
        public virtual Warranty Warranty { get; set; }
        [InverseProperty("Equipment")]
        public virtual OnboarderEquipment OnboarderEquipment { get; set; }
    }
}
