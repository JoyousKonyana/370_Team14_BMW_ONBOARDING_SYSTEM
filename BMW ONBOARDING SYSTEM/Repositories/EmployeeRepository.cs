using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public EmployeeRepository(INF370DBContext inf370ContextDB)
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

        public async Task<Employee[]> GetAllEmployeesAsync()
        {
            IQueryable<Employee> results = _inf370ContextDB.Employee.Include(x => x.Department).Include(x => x.Title).Include(x => x.Onboarder);

            return await results.ToArrayAsync();
        }

        public Task<Employee> GetEmployeeByID(int id)
        {
            IQueryable<Employee> result = _inf370ContextDB.Employee.Where(i => i.EmployeeId == id);
            return result.FirstOrDefaultAsync();
        }





        public Task<Employee> GetEmployeeByUserID(int id)
        {

            //Change to user ID
            IQueryable<Employee> result = _inf370ContextDB.Employee.Where(i => i.EmployeeId == id);
            return result.FirstOrDefaultAsync();
        }

        public Task<Employee[]> GetEmployeeByNameAsync(string name)
        {
            IQueryable<Employee> results = _inf370ContextDB.Employee.
                Where(en => en.FirstName.Contains(name));

            //course = course.Where(c => c.CourseName == name);

            return results.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }

        public void CreateOnboarder<T>(T entity) where T : class
        {
            _inf370ContextDB.Add(entity);
        }
    }
}
