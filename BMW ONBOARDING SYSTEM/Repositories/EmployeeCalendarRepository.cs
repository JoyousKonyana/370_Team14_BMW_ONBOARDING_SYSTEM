using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class EmployeeCalendarRepository : IEmployeeCalendarRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public EmployeeCalendarRepository(INF370DBContext inf370ContextDB)
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

        public async Task<EmployeeCalendar[]> GetAllLinksAsync()
        {
            IQueryable<EmployeeCalendar> result = _inf370ContextDB.EmployeeCalendar;

            return await result.ToArrayAsync(); ;
        }

        public Task<EmployeeCalendar> GetEmployeeLinkByIdAsync(int Id)
        {
            IQueryable<EmployeeCalendar> results = _inf370ContextDB.EmployeeCalendar.Where(i => i.EmployeeCalendarId == Id);

            return results.FirstOrDefaultAsync();

        }

        // needs implementation after tables relationship is fixed
        public Task<EmployeeCalendar> GetLinkForUser()
        {
            throw new NotImplementedException();
        }

        //public Task<EmployeeCalendar> GetlinkByNameAsync(string name)
        //{
        //    IQueryable<Course> course = _inf370ContextDB.Course.Where(cc => cc.CourseName == name);

        //    course = course.Where(c => c.CourseName == name);

        //    return course.FirstOrDefaultAsync();
        //}

        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }
    }
}
