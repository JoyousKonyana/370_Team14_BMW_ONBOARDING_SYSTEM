using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            User = new HashSet<User>();
        }

        [Key]
        [Column("UserRoleID")]
        public int UserRoleId { get; set; }
        [StringLength(50)]
        public string UserRoleDescription { get; set; }
        [StringLength(50)]
        public string UserRoleName { get; set; }

        [InverseProperty("UserRole")]
        public virtual ICollection<User> User { get; set; }
    }
}
