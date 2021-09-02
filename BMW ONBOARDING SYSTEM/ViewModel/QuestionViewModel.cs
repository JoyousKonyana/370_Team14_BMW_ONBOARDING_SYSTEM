using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.ViewModel
{
    public class QuestionViewModel
    {
        public int? QuizId { get; set; }
        public int? QuestionCategoryId { get; set; }
        public string QuestionDescription { get; set; }
        public string QuestionAnswer { get; set; }
        public decimal? QuestionMarkAllocation { get; set; }
    }
}
