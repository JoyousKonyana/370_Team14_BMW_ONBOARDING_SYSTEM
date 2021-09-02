using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class LessonCompletionStatus
    {
        public LessonCompletionStatus()
        {
            Lesson = new HashSet<Lesson>();
        }

        [Key]
        [Column("LessonCompletionStatusID")]
        public int LessonCompletionStatusId { get; set; }
        [StringLength(50)]
        public string LessonCompletionStatusDescription { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LessonCompletionDate { get; set; }

        [InverseProperty("LessonCompletionStatus")]
        public virtual ICollection<Lesson> Lesson { get; set; }
    }
}
