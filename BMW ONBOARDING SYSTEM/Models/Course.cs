using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class Course
    {
        public Course()
        {
            OnboarderCourseEnrollment = new HashSet<OnboarderCourseEnrollment>();
        }

        [Key]
        [Column("CourseID")]
        public int CourseId { get; set; }
        [StringLength(50)]
        public string CourseDescription { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CourseDueDate { get; set; }
        [StringLength(50)]
        public string CourseName { get; set; }

        [InverseProperty("Course")]
        public virtual ICollection<OnboarderCourseEnrollment> OnboarderCourseEnrollment { get; set; }
    }
}
