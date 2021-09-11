using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class EquipmentTypeRepository : IEquipementTypeRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public EquipmentTypeRepository(INF370DBContext inf370ContextDB)
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


        public async Task<EquipmentType[]> GetAllEquipmentTypesAsync()
        {

            IQueryable<EquipmentType> equipmentTypes = _inf370ContextDB.EquipmentType;
            return await equipmentTypes.ToArrayAsync();

        }

        public Task<EquipmentType> GetEquipmentTypeByIdAsync(int equipmentID)
        {
            IQueryable<EquipmentType> existingEquipmentType = _inf370ContextDB.EquipmentType.Where(x => x.EquipmentTypeId == equipmentID);

            return existingEquipmentType.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }

    }
}
