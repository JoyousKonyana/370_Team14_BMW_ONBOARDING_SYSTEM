using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public ProvinceRepository(INF370DBContext inf370ContextDB)
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




        public Task<Province> GetProvinceByIdAsync(int provinceId)
        {
            IQueryable<Province> existingProvince = _inf370ContextDB.Province.Where(x => x.ProvinceId == provinceId);

            return existingProvince.FirstOrDefaultAsync();
        }

        public Task<Province> GetProvinceNameAsync(string name)
        {
            IQueryable<Province> existingProvince = _inf370ContextDB.Province.Where(x => x.ProvinceName == name);

            return existingProvince.FirstOrDefaultAsync();
        }

        public async Task<Province[]> GetProvincesAsync()
        {
            IQueryable<Province> provinces = _inf370ContextDB.Province;

            return await provinces.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }
    }
}
