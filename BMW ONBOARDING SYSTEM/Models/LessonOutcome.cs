using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class LessonOutcome
    {
        [Key]
        [Column("LessonOutcomeID")]
        public int LessonOutcomeId { get; set; }
        [Column("LessonID")]
        public int? LessonId { get; set; }
        [StringLength(50)]
        public string LessonOutcomeDescription { get; set; }
        [StringLength(50)]
        public string LessonOutcomeName { get; set; }
    }
}
