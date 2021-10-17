using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class Lesson
    {
        [Key]
        [Column("LessonID")]
        public int LessonId { get; set; }
        [Column("CourseID")]
        public int? CourseId { get; set; }
        [Column("LessonCompletionStatusID")]
        public int? LessonCompletionStatusId { get; set; }
        [StringLength(50)]
        public string LessonDescription { get; set; }
        [StringLength(50)]
        public string LessonName { get; set; }
    }
}
