using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class LessonContentType
    {
        public LessonContentType()
        {
            LessonContent = new HashSet<LessonContent>();
        }
        [Key]
        [Column("LessonContentTypeID")]
        public int LessonContentTypeId { get; set; }
        [StringLength(50)]
        public string LessonContentDescription { get; set; }

        public virtual ICollection<LessonContent> LessonContent { get; set; }
    }
}
