using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class AuditLog
    {
        [Key]
        [Column("AuditLogID")]
        public int AuditLogId { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? AuditLogDatestamp { get; set; }
        public TimeSpan? AuditLogTimestamp { get; set; }
        [StringLength(50)]
        public string AuditLogDescription { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("AuditLog")]
        public virtual User User { get; set; }
    }
}
