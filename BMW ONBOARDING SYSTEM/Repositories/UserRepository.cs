using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public UserRepository(INF370DBContext inf370ContextDB)
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

        public Task<UserRole[]> getAllUserRoles()
        {
            throw new NotImplementedException();
        }

        public Task<User[]> GetAllUsersAsync()
        {
            IQueryable<User> user = _inf370ContextDB.User;

            return user.ToArrayAsync();
        }

        public Task<User> GetUserByemail(string email)
        {
            IQueryable<User> user = _inf370ContextDB.User.

                Include(r => r.UserRole).
                Where(x => x.Username == email);

            return user.FirstOrDefaultAsync();
        }

        public Task<User> GetUserByIdAsync(int userId)
        {
            IQueryable<User> user = _inf370ContextDB.User.Include(x => x.Employee).
                Include(x => x.UserRole).
                Where(x => x.UserId == userId);

            //course = course.Where(c => c.CourseName == name);

            return user.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }
    }
}
