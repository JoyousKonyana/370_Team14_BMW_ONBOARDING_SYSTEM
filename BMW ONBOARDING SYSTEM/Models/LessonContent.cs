using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class LessonContent
    {
        [Key]
        [Column("LessonConentID")]
        public int LessonConentId { get; set; }
        [Column("LessonContenetTypeID")]
        public int? LessonContenetTypeId { get; set; }
        [Column("LessonOutcomeID")]
        public int? LessonOutcomeId { get; set; }
        [Column("ArchiveStatusID")]
        public int? ArchiveStatusId { get; set; }
        [StringLength(50)]
        public string LessonContentDescription { get; set; }
        [Column("LessonContent")]
        public string LessonContent1 { get; set; }

        [ForeignKey(nameof(ArchiveStatusId))]
        [InverseProperty("LessonContent")]
        public virtual ArchiveStatus ArchiveStatus { get; set; }
        [ForeignKey(nameof(LessonContenetTypeId))]
        [InverseProperty(nameof(LessonContentType.LessonContent))]
        public virtual LessonContentType LessonContenetType { get; set; }
        [ForeignKey(nameof(LessonOutcomeId))]
        [InverseProperty("LessonContent")]
        public virtual LessonOutcome LessonOutcome { get; set; }
    }
}
