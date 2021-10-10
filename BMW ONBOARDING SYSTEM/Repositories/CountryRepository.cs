using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public CountryRepository(INF370DBContext inf370ContextDB)
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

        public async Task<Country[]> GetCountriesAsync()
        {
            IQueryable<Country> countries = _inf370ContextDB.Country;

            return await countries.ToArrayAsync();
        }

        public Task<Country> GetCountryByIdAsync(int countryId)
        {
            IQueryable<Country> existingCountry = _inf370ContextDB.Country;

            return existingCountry.FirstOrDefaultAsync();

        }

        public Task<Country> GetCountryByNameAsync(string name)
        {
            IQueryable<Country> existingCountry = _inf370ContextDB.Country.Where(x => x.CountryName == name);

            return existingCountry.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {

            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }

    }
}
