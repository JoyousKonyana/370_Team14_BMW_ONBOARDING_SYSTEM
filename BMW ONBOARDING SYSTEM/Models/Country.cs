using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class Country
    {
        [Key]
        [Column("CountryID")]
        public int CountryId { get; set; }
        [StringLength(50)]
        public string CountryName { get; set; }
    }
}
