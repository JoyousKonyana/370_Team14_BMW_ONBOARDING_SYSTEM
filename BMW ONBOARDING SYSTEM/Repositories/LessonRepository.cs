using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public LessonRepository(INF370DBContext inf370ContextDB)
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
        public async Task<Lesson[]> GetAllLessonAsync()
        {
            IQueryable<Lesson> lessons = _inf370ContextDB.Lesson;

            return await lessons.ToArrayAsync();
        }



        public Task<Lesson[]> GetLessonByCourseIdAsync(int courseID)
        {
            IQueryable<Lesson> existingLesson = _inf370ContextDB.Lesson.Where(id => id.CourseId == courseID);


            return existingLesson.ToArrayAsync();
        }

        public Task<Lesson> GetLessonByIdAsync(int lessonID)
        {
            IQueryable<Lesson> existingLesson = _inf370ContextDB.Lesson.Where(id => id.LessonId == lessonID);


            return existingLesson.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }
    }
}
