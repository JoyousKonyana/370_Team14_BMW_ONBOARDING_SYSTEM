using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class CourseCompletionStatus
    {
        [Column("CourseCopletionStatusID")]
        public int CourseCopletionStatusId { get; set; }
        [Column("OnboarderID")]
        public int? OnboarderId { get; set; }
        [Column("CourseID")]
        public int? CourseId { get; set; }
        [StringLength(50)]
        public string CourseCompletionStatusDescription { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CourseCompletionStatusDate { get; set; }
    }
}
