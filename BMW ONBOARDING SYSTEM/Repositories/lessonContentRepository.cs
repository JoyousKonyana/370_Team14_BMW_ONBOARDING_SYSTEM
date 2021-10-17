using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class lessonContentRepository : ILessonContentRepository
    {

        private readonly INF370DBContext _inf370ContextDB;

        public lessonContentRepository(INF370DBContext inf370ContextDB)
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



        public Task<LessonContent[]> GetLessonContentByLessonOutcomeIDsAsync(int Id)
        {
            IQueryable<LessonContent> result = _inf370ContextDB.LessonContent.Where(xx => xx.LessonOutcomeId == Id).
                Include(l => l.LessonContentType).
                Include(l => l.ArchiveStatus);


            return result.ToArrayAsync();
        }

        public Task<LessonContent> GetLessonContentByIdAsync(int id)
        {
            IQueryable<LessonContent> result = _inf370ContextDB.LessonContent.Where(i => i.LessonOutcomeId == id);
            return result.FirstOrDefaultAsync();
        }

        public Task<LessonContent[]> GetLessonContentsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }


    }
}
