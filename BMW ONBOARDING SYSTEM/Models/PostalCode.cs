using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class PostalCode
    {
        [Key]
        [Column("PostalCodeID")]
        public int PostalCodeId { get; set; }
        [Column("PostalCode")]
        [StringLength(50)]
        public string PostalCode1 { get; set; }
    }
}
