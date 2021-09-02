using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public UserRoleRepository(INF370DBContext inf370ContextDB)
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
        public Task<UserRole> GetUserRoleByIdAsync(int id)
        {
            IQueryable<UserRole> existingCourse = _inf370ContextDB.UserRole.
                Where(i => i.UserRoleId == id);
            return existingCourse.FirstOrDefaultAsync();

        }

        public async Task<UserRole[]> getAllUserRoles()
        {
            IQueryable<UserRole> userRole = _inf370ContextDB.UserRole;


            return await userRole.ToArrayAsync();
        }
        public async Task<UserRole> GetUserRoleByid(int id)
        {
            IQueryable<UserRole> userRole = _inf370ContextDB.UserRole.
                Where(x => x.UserRoleId == id);


            return await userRole.FirstOrDefaultAsync();
        }

        public Task<UserRole> GetUserRoleByname(string name)
        {
            IQueryable<UserRole> userRole = _inf370ContextDB.UserRole.Where(cc => cc.UserRoleName == name);

            //course = course.Where(c => c.CourseName == name);

            return userRole.FirstOrDefaultAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }
    }
}
