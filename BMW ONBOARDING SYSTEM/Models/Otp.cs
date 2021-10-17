using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    [Table("OTP")]
    public partial class Otp
    {
        [Key]
        [Column("OTP_ID")]
        public int OtpId { get; set; }
        [Column("User_ID")]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string OtpValue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Timestamp { get; set; }
    }
}
