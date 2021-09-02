﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class City
    {
        public City()
        {
            Address = new HashSet<Address>();
        }

        [Key]
        [Column("CityID")]
        public int CityId { get; set; }
        [StringLength(50)]
        public string Country { get; set; }

        [InverseProperty("City")]
        public virtual ICollection<Address> Address { get; set; }
    }
}
