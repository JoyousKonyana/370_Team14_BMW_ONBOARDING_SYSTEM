using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public DepartmentRepository(INF370DBContext inf370ContextDB)
        {
            _inf370ContextDB = inf370ContextDB;
        }
        public async Task<Department[]> GetDepartmentAsync()
        {
            IQueryable<Department> result = _inf370ContextDB.Department;

            return await result.ToArrayAsync();
        }

        public async Task<Department> GetDepartmentByName(string name)
        {
            IQueryable<Department> result = _inf370ContextDB.Department.Where(x => x.DepartmentDescription == name);

            return await result.FirstOrDefaultAsync();
        }
    }
}
