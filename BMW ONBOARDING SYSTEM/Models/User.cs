using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class User
    {
        public User()
        {
            AuditLog = new HashSet<AuditLog>();
        }

        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        public string Password { get; set; }
        [Column("EmployeeID")]
        public int? EmployeeId { get; set; }
        [InverseProperty("User")]
        public virtual Employee Employee { get; set; }
        [Column("UserRoleID")]
        public int? UserRoleId { get; set; }

        [ForeignKey(nameof(UserRoleId))]
        [InverseProperty("User")]
        public virtual UserRole UserRole { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<AuditLog> AuditLog { get; set; }
    }
}
