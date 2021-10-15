using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public QuizRepository(INF370DBContext inf370ContextDB)
        {
            _inf370ContextDB = inf370ContextDB;
        }
        public void Add<T>(T entity) where T : class
        {
            _inf370ContextDB.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _inf370ContextDB.Remove(entity);
        }

        public Task<Quiz> GetQuizByIDAsync(int quizId)
        {

            // we also need to include possible answers
            IQueryable<Quiz> result = _inf370ContextDB.Quiz.Where(q => q.QuizId == quizId).Include(x => x.Question).ThenInclude(x => x.Option);
            return result.FirstOrDefaultAsync();

        }

        public Task<Quiz> GetQuizByLessonOutcomeIDAsync(int lessonOutcomeId)
        {
            IQueryable<Quiz> result = _inf370ContextDB.Quiz.Where(q => q.LessonOutcomeId == lessonOutcomeId).Include(x => x.Question).ThenInclude(x => x.Option);
            return result.FirstOrDefaultAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }
    }
}
