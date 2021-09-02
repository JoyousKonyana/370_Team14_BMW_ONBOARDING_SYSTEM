using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class LessonOutcome
    {
        public LessonOutcome()
        {
            LessonContent = new HashSet<LessonContent>();
            Quiz = new HashSet<Quiz>();
        }

        [Key]
        [Column("LessonOutcomeID")]
        public int LessonOutcomeId { get; set; }
        [Column("LessonID")]
        public int? LessonId { get; set; }
        [StringLength(50)]
        public string LessonOutcomeDescription { get; set; }
        [StringLength(50)]
        public string LessonOutcomeName { get; set; }

        [ForeignKey(nameof(LessonId))]
        [InverseProperty("LessonOutcome")]
        public virtual Lesson Lesson { get; set; }
        [InverseProperty("LessonOutcome")]
        public virtual ICollection<LessonContent> LessonContent { get; set; }
        [InverseProperty("LessonOutcome")]
        public virtual ICollection<Quiz> Quiz { get; set; }
    }
}
