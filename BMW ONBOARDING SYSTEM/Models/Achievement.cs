using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_ONBOARDING_SYSTEM.Models
{
    public partial class Achievement
    {
        [Key]
        [Column("AchievementID")]
        public int AchievementId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AchievementDate { get; set; }
        [Column("AchievementTypeID")]
        public int? AchievementTypeId { get; set; }
        [Column("OnboarderID")]
        public int? OnboarderId { get; set; }
        [Column("CourseID")]
        public int? CourseId { get; set; }
        [Column("QuizID")]
        public int? QuizId { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? MarkAchieved { get; set; }
    }
}
