using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class Warranty
    {
        public Warranty()
        {
            Equipment = new HashSet<Equipment>();
        }

        [Key]
        [Column("WarrantyID")]
        public int WarrantyId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? WarrantyStartDate { get; set; }
        [Column("WarrantyENdDate", TypeName = "datetime")]
        public DateTime? WarrantyEndDate { get; set; }
        [StringLength(50)]
        public string WarrantyStatus { get; set; }

        [InverseProperty("Warranty")]
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
