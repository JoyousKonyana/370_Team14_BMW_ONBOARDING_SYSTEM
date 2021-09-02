using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class EquipmentType
    {
        public EquipmentType()
        {
            Equipment = new HashSet<Equipment>();
        }

        [Key]
        [Column("EquipmentTypeID")]
        public int EquipmentTypeId { get; set; }
        [StringLength(50)]
        public string EquipmentTypeDescription { get; set; }

        [InverseProperty("EquipmentType")]
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
