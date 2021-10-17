using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class OnboarderCourseEnrollment
    {
        [Key]
        [Column("OnboarderID")]
        public int OnboarderId { get; set; }
        [Key]
        [Column("CourseID")]
        public int CourseId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OnboarderEnrollmentDate { get; set; }
        public int BadgeTotal { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OnboarderGraduationDate { get; set; }

        [ForeignKey(nameof(CourseId))]
        [InverseProperty("OnboarderCourseEnrollment")]
        public virtual Course Course { get; set; }
        [ForeignKey(nameof(OnboarderId))]
        [InverseProperty("OnboarderCourseEnrollment")]
        public virtual Onboarder Onboarder { get; set; }
    }
}
