using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class Badge
    {
        public Badge()
        {
            AchievementType = new HashSet<AchievementType>();
        }

        [Key]
        [Column("BadgeID")]
        public int BadgeId { get; set; }
        [StringLength(50)]
        public string BadgeDecription { get; set; }

        [InverseProperty("Badge")]
        public virtual ICollection<AchievementType> AchievementType { get; set; }
    }
}
