using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Onboarder = new HashSet<Onboarder>();
            User = new HashSet<User>();
        }

        [Key]
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        [Column("DepartmentID")]
        public int? DepartmentId { get; set; }
        [Column("GenderID")]
        public int? GenderId { get; set; }
        [Column("AddressID")]
        public int? AddressId { get; set; }
        [Column("EmployeeCalendarID")]
        public int? EmployeeCalendarId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string MiddleName { get; set; }
        [Column("IDNumber", TypeName = "numeric(18, 0)")]
        public decimal? Idnumber { get; set; }
        [StringLength(50)]
        public string EmailAddress { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? ContactNumber { get; set; }
        [StringLength(50)]
        public string EmployeeJobTitle { get; set; }
        [Column("TitleID")]
        public int? TitleId { get; set; }
        [InverseProperty("Employee")]
        public virtual Title Title { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Employee")]
        public virtual Department Department { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<Onboarder> Onboarder { get; set; }

        [InverseProperty("Employee")]
        public virtual ICollection<User> User { get; set; }
    }
}
