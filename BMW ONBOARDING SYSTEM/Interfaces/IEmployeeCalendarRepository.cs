using BMW_ONBOARDING_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Interfaces
{
    public interface IEmployeeCalendarRepository
    {
        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        Task<EmployeeCalendar[]> GetAllLinksAsync();

        Task<EmployeeCalendar> GetEmployeeLinkByIdAsync(int Id);

        Task<EmployeeCalendar> GetLinkForUser();
        //Task<EmployeeCalendar> GetCourseByNameAsync(string name)
    }
}
