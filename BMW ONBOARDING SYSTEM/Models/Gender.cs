using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class Gender
    {
        [Key]
        [Column("GenderID")]
        public int GenderId { get; set; }
        [StringLength(50)]
        public string GenderDescription { get; set; }
    }
}
