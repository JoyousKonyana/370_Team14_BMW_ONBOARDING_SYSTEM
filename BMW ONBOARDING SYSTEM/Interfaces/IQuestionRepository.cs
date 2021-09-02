using BMW_ONBOARDING_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Interfaces
{
    public interface IQuestionRepository
    {
        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;
        Task<Question> GetQuestionByquestionIDAsync(int questionID);
        Task<Question[]> GetQuestionByQuizIDAsync(int quizID);

        Task<Question[]> GetQuestionAllquestionAsync();
        Task<bool> SaveChangesAsync();
    }
}
