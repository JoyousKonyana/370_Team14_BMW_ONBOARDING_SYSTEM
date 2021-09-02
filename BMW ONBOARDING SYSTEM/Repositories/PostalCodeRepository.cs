using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class PostalCodeRepository : IPostalCodeRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public PostalCodeRepository(INF370DBContext inf370ContextDB)
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

        public Task<PostalCode> GetPostCodeByIdAsync(int postCodeId)
        {
            IQueryable<PostalCode> existingPostCode = _inf370ContextDB.PostalCode;

            return existingPostCode.FirstOrDefaultAsync();
        }

        public async Task<PostalCode[]> GetPostCodesAsync()
        {
            IQueryable<PostalCode> postalCodes = _inf370ContextDB.PostalCode;

            return await postalCodes.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }
    }
}
