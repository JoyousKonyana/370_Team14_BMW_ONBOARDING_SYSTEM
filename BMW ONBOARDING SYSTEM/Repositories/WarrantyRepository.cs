//using BMW_ONBOARDING_SYSTEM.Interfaces;
//using BMW_ONBOARDING_SYSTEM.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace BMW_ONBOARDING_SYSTEM.Repositories
//{
//    public class WarrantyRepository : IWarrantyRepository
//    {

//        private readonly INF370DBContext _inf370ContextDB;

//        public WarrantyRepository(INF370DBContext inf370ContextDB)
//        {
//            _inf370ContextDB = inf370ContextDB;
//        }
//        public void Add<T>(T entity) where T : class
//        {
//            _inf370ContextDB.Add(entity);
//        }

//        public void Delete<T>(T entity) where T : class
//        {
//            _inf370ContextDB.Remove(entity);
//        }

//        public Task<Warranty> GetWarrantyByIdAsync(int warrantyId)
//        {
//            IQueryable<Warranty> existingWarranty = _inf370ContextDB.Warranty.Where(x => x.WarrantyId == warrantyId);

//            return existingWarranty.FirstOrDefaultAsync();

//        }

//        public async Task<Warranty[]> GetWarrantiesAsync()
//        {
//            IQueryable<Warranty> warranties = _inf370ContextDB.Warranty;

//            return await warranties.ToArrayAsync();
//        }

//        public async Task<bool> SaveChangesAsync()
//        {
//            return await _inf370ContextDB.SaveChangesAsync() > 0;
//        }
//    }
//}
