using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.ViewModel
{
    public class CreateQuizViewModel2
    {

        // data to add quiz
        public int? LessonOutcomeId { get; set; }
        public string QuizDescription { get; set; }
        public string QuizMarkRequirement { get; set; }
        public DateTime? QuizDueDate { get; set; }
        public DateTime? QuizCompletionDate { get; set; }
        public decimal? NumberOfQuestions { get; set; }

        // data to add a question
        //public int? QuizId { get; set; }
        //public int? QuestionCategoryId { get; set; }
        //public string QuestionDescription { get; set; }
        //public string QuestionAnswer { get; set; }
        //public decimal? QuestionMarkAllocation { get; set; }
       public List<QuestionViewModel> questions { get; set; }

        //data to add options

        public List<OptionsViewModel> questionOptions { get; set; }
    }
}
