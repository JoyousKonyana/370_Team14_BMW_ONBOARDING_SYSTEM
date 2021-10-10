using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public CityRepository(INF370DBContext inf370ContextDB)
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

        public Task<City> GetCityyByIdAsync(int cityyId)
        {
            IQueryable<City> existingCity = _inf370ContextDB.City;

            return existingCity.FirstOrDefaultAsync();
        }

        public Task<City> GetCityyByNameAsync(string name)
        {
            IQueryable<City> existingCity = _inf370ContextDB.City.Where(x => x.Country == name);

            return existingCity.FirstOrDefaultAsync();
        }

        public async Task<City[]> GetCtiessAsync()
        {
            IQueryable<City> cities = _inf370ContextDB.City;

            return await cities.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }
    }
}
