using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            Question = new HashSet<Question>();
        }
        [Key]
        [Column("QuizID")]
        public int QuizId { get; set; }
        [Column("LessonOutcomeID")]
        public int? LessonOutcomeId { get; set; }
        [StringLength(50)]
        public string QuizDescription { get; set; }
        [StringLength(50)]
        public string QuizMarkRequirement { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? QuizDueDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? QuizCompletionDate { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? NumberOfQuestions { get; set; }

        [InverseProperty("Quiz")]
        public virtual ICollection<Question> Question { get; set; }
    }
}
