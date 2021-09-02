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
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? StreetNumber { get; set; }
        [StringLength(50)]
        public string StreetName { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("Address")]
        public virtual City City { get; set; }
        [ForeignKey(nameof(CountryId))]
        [InverseProperty("Address")]
        public virtual Country Country { get; set; }
        [ForeignKey(nameof(ProvinceId))]
        [InverseProperty("Address")]
        public virtual Province Province { get; set; }
        [ForeignKey(nameof(SuburbId))]
        [InverseProperty("Address")]
        public virtual Suburb Suburb { get; set; }
    }
}
