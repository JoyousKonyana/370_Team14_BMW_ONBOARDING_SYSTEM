using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class ActiveLog
    {
        [Key]
        [Column("ActiveLogID")]
        public int ActiveLogId { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }
        [Column("ActiveLogDeviceIPAddress")]
        [StringLength(50)]
        public string ActiveLogDeviceIpaddress { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ActiveLogLoginTimestamp { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ActiveLogLoginLastActiveTimestamp { get; set; }
    }
}
