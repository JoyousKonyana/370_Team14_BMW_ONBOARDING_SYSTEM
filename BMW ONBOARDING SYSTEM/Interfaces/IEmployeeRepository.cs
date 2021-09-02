using BMW_ONBOARDING_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Interfaces
{
    public interface IEmployeeRepository
    {
        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        Task<Employee[]> GetAllEmployeesAsync();

        Task<Employee> GetEmployeeByUserID(int id);

        Task<Employee> GetEmployeeByID(int id);
        Task<Employee[]> GetEmployeeByNameAsync(string name);

        void CreateOnboarder<T>(T entity) where T : class;
    }
}
