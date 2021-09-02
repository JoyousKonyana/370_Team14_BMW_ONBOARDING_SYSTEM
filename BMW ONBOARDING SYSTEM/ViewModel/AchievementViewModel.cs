using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.ViewModel
{
    public class AchievementViewModel
    {
        public int AchievementId { get; set; }
        public DateTime? AchievementDate { get; set; }
        public int? AchievementTypeId { get; set; }
        public int? OnboarderId { get; set; }
        public int? CourseId { get; set; }
        public int? QuizId { get; set; }
        public decimal? MarkAchieved { get; set; }
    }
}
