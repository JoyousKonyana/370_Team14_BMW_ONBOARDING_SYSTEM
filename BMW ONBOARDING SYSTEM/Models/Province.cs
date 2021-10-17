using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class Province
    {
        [Key]
        [Column("ProvinceID")]
        public int ProvinceId { get; set; }
        [StringLength(50)]
        public string ProvinceName { get; set; }
    }
}
