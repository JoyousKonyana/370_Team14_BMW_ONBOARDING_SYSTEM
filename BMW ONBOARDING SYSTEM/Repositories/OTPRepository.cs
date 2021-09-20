using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class OTPRepository : IOTPRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public OTPRepository(INF370DBContext inf370ContextDB)
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

        public Task<Otp> AuthoriseUserAsync(int userid)
        {
            IQueryable<Otp> otp = _inf370ContextDB.Otp.Where(x => x.UserId == userid).OrderByDescending(x => x.Timestamp).Take(1);
            return otp.LastOrDefaultAsync();
        }



        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }
    }
}
