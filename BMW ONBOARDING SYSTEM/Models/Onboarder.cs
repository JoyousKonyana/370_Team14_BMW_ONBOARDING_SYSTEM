using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class Onboarder
    {
        public Onboarder()
        {
            OnboarderCourseEnrollment = new HashSet<OnboarderCourseEnrollment>();
            OnboarderEquipment = new HashSet<OnboarderEquipment>();
        }

        [Key]
        [Column("OnboarderID")]
        public int OnboarderId { get; set; }
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("Onboarder")]
        public virtual Employee Employee { get; set; }
        [InverseProperty("Onboarder")]
        public virtual ICollection<OnboarderCourseEnrollment> OnboarderCourseEnrollment { get; set; }
        [InverseProperty("Onboarder")]
        public virtual ICollection<OnboarderEquipment> OnboarderEquipment { get; set; }
    }
}
