using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class Title
    {
        public Title()
        {
            Employee = new HashSet<Employee>();
        }

        [Key]
        [Column("TitleID")]
        public int TitleId { get; set; }
        [StringLength(50)]
        public string TitleDescription { get; set; }

        [InverseProperty("Title")]
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
