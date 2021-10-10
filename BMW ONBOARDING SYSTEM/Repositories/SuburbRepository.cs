using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class SuburbRepository : ISuburbRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public SuburbRepository(INF370DBContext inf370ContextDB)
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

        public Task<Suburb> GetSubburbByIdAsync(int suburbid)
        {
            IQueryable<Suburb> existingSuburb = _inf370ContextDB.Suburb;

            return existingSuburb.FirstOrDefaultAsync();
        }

        public Task<Suburb> GetSuburbByName(string name)
        {
            IQueryable<Suburb> existingSuburb = _inf370ContextDB.Suburb.Where(x => x.SuburbName == name);

            return existingSuburb.FirstOrDefaultAsync();
        }

        public async Task<Suburb[]> GetSuburbsAsync()
        {
            IQueryable<Suburb> suburbs = _inf370ContextDB.Suburb;

            return await suburbs.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }
    }
}
