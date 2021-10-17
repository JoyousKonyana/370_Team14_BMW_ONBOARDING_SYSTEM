using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.ViewModel
{
    public class QuizViewModel
    {
     


       
        public int? LessonOutcomeId { get; set; }
      
        public string QuizDescription { get; set; }
     
        public string QuizMarkRequirement { get; set; }
       
        public DateTime? QuizDueDate { get; set; }
      
        public DateTime? QuizCompletionDate { get; set; }
     
        public decimal? NumberOfQuestions { get; set; }
    }
}
