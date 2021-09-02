using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class EquipmentBrand
    {
        public EquipmentBrand()
        {
            Equipment = new HashSet<Equipment>();
        }

        [Key]
        [Column("EquipmentBrandID")]
        public int EquipmentBrandId { get; set; }
        [StringLength(50)]
        public string EquipmentBrandName { get; set; }

        [InverseProperty("EquipmentBrand")]
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
