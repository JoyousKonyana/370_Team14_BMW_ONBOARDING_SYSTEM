using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public GenderRepository(INF370DBContext inf370ContextDB)
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


        public async Task<Gender[]> GetAllGenderAsync()
        {
            IQueryable<Gender> genders = _inf370ContextDB.Gender;

            return await genders.ToArrayAsync();
        }

        public Task<Gender> GetGenderByIdAsync(int genderID)
        {
            IQueryable<Gender> existingGender = _inf370ContextDB.Gender.Where(x => x.GenderId == genderID);

            return existingGender.FirstOrDefaultAsync();
        }

        public Task<Gender> GetGenderByName(string name)
        {
            IQueryable<Gender> existingGender = _inf370ContextDB.Gender.Where(x => x.GenderDescription == name);

            return existingGender.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }
    }
}
