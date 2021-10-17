using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class Suburb
    {
        [Key]
        [Column("SuburbID")]
        public int SuburbId { get; set; }
        [Column("PostalCodeID")]
        public int? PostalCodeId { get; set; }
        [StringLength(50)]
        public string SuburbName { get; set; }
    }
}
