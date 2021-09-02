using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class ArchiveStatus
    {
        public ArchiveStatus()
        {
            LessonContent = new HashSet<LessonContent>();
        }

        [Key]
        [Column("ArchiveStatusID")]
        public int ArchiveStatusId { get; set; }
        [StringLength(50)]
        public string ArchieveStatusDescription { get; set; }

        [InverseProperty("ArchiveStatus")]
        public virtual ICollection<LessonContent> LessonContent { get; set; }
    }
}
