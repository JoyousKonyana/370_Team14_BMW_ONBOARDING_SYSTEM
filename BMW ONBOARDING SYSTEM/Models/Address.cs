using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class Address
    {
        [Key]
        [Column("AddressID")]
        public int AddressId { get; set; }
        [Column("SuburbID")]
        public int? SuburbId { get; set; }
        [Column("ProvinceID")]
        public int? ProvinceId { get; set; }
        [Column("CityID")]
        public int? CityId { get; set; }
        [Column("CountryID")]
        public int? CountryId { get; set; }
        public string StreetNumber { get; set; }
        [StringLength(50)]
        public string StreetName { get; set; }
    }
}
