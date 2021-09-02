using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class CourseRepository : ICourseRepository
    {

        private readonly INF370DBContext _inf370ContextDB;

        public CourseRepository(INF370DBContext inf370ContextDB)
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

        public Task<Course> GetCourseByIdAsync(int courseId)
        {
            IQueryable<Course> existingCourse = _inf370ContextDB.Course.Where(id => id.CourseId == courseId);



            return existingCourse.FirstOrDefaultAsync();

        }


        public async Task<Course[]> GetAllCoursesAsync()
        {
            IQueryable<Course> course = _inf370ContextDB.Course.OrderBy(c =>
            c.CourseDescription);

            return await course.ToArrayAsync();
        }

        public Task<Course> GetCourseByNameAsync(string name)
        {
            IQueryable<Course> course = _inf370ContextDB.Course.Where(cc => cc.CourseName == name);

            course = course.Where(c => c.CourseName == name);

            return course.FirstOrDefaultAsync();
        }
        public Task<OnboarderCourseEnrollment[]> GetCourseonoarderIDAsync(int onboarderID)
        {
            IQueryable<OnboarderCourseEnrollment> course = _inf370ContextDB.OnboarderCourseEnrollment.
                Include(x => x.Course).
                Where(cc => cc.OnboarderId == onboarderID);

            //course = course.Where(c => c.CourseName == name);

            return course.ToArrayAsync();
        }


        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }


    }
}
