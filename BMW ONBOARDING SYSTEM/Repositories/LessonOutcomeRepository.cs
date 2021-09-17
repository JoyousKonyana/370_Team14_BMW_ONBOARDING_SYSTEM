using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class LessonOutcomeRepository : ILessonOutcome
    {
        private readonly INF370DBContext _inf370ContextDB;

        public LessonOutcomeRepository(INF370DBContext inf370ContextDB)
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

        public Task<LessonOutcome> GetLessonOutcomeIdAsync(int lessonOutcomeId)
        {
            IQueryable<LessonOutcome> existingLessonOutcome = _inf370ContextDB.LessonOutcome.
                Where(id => id.LessonOutcomeId == lessonOutcomeId);

            return existingLessonOutcome.FirstOrDefaultAsync();
        }

        public async Task<LessonOutcome[]> GetAllLessonOutcomesAsync()
        {
            IQueryable<LessonOutcome> lessonOutcomes = _inf370ContextDB.LessonOutcome;

            return await lessonOutcomes.ToArrayAsync();
        }



        public Task<LessonOutcome> GetLessonOutcomeByNameAsync(string name)
        {
            //Query using name
            IQueryable<LessonOutcome> lessonOutcome = _inf370ContextDB.LessonOutcome.Where(ll => ll.LessonOutcomeName == name);

            //lessonOutcome = lessonOutcome.Where(c => c.CourseName == name);



            return lessonOutcome.FirstOrDefaultAsync();
        }


        // change to lessonid
        public async Task<LessonOutcome[]> GeLessonOutcomeByLessonId(int lessonID)
        {
            //Lesson lesson1 = _inf370ContextDB.Lesson.Where(cd =>
            //cd.CourseId == lessonOutcomeId).FirstOrDefault();

            IQueryable<LessonOutcome> lessonout = _inf370ContextDB.LessonOutcome.Where(xx => xx.LessonId == lessonID);

            return await lessonout.ToArrayAsync();

        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }
    }
}
