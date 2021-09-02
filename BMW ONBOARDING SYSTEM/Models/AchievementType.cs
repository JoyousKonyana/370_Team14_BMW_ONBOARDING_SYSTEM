using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class AchievementType
    {
        [Key]
        [Column("AchievementTypeID")]
        public int AchievementTypeId { get; set; }
        [StringLength(50)]
        public string AchievementTypeDescription { get; set; }
        [Column("BadgeID")]
        public int? BadgeId { get; set; }

        [ForeignKey(nameof(BadgeId))]
        [InverseProperty("AchievementType")]
        public virtual Badge Badge { get; set; }
    }
}
