using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class Province
    {
        public Province()
        {
            Address = new HashSet<Address>();
        }

        [Key]
        [Column("ProvinceID")]
        public int ProvinceId { get; set; }
        [StringLength(50)]
        public string ProvinceName { get; set; }

        [InverseProperty("Province")]
        public virtual ICollection<Address> Address { get; set; }
    }
}
