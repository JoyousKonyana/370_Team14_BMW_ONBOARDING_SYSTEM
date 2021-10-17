using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using BMW_ONBOARDING_SYSTEM.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public EquipmentRepository(INF370DBContext inf370ContextDB)
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

        public Task<OnboarderEquipment[]> GetEquipmentByOnboarderIDAsync(int id)
        {
            IQueryable<OnboarderEquipment> onboarderEquipment = _inf370ContextDB.OnboarderEquipment.
                Include(x => x.Equipment)
                //ThenInclude(x => x.EquipmentTradeInStatus)
              //ThenInclude(x => x.Equipment).ThenInclude(x => x.EquipmentBrand)
              .Where(i => i.OnboarderId == id);

            return onboarderEquipment.ToArrayAsync();
        }

        public Task<Equipment> GetEquipmentByIdAsync(int id)
        {
            IQueryable<Equipment> existingEquipment = _inf370ContextDB.Equipment
                .Where(i => i.EquipmentId == id);

            return existingEquipment.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }

        public Task<OnboarderEquipment> GetEquipmentByEquipmentOnboarderId(int onboarderid, int equipmentid)
        {
            IQueryable<OnboarderEquipment> existingEquipment = _inf370ContextDB.OnboarderEquipment
               .Where(i => i.EquipmentId == equipmentid && i.OnboarderId == onboarderid);

            return existingEquipment.FirstOrDefaultAsync();
        }

        public Task<Equipment[]> GenerateEquipmentReport(AuditLogViewModel model)
        {
            IQueryable<Equipment> equipment = _inf370ContextDB.Equipment.
                Include(x => x.EquipmentBrand).
                Include(x => x.EquipmentTradeInStatus).
                Include(x => x.EquipmentType).
                Include(x => x.OnboarderEquipment); //ThenInclude(x => x.EquipmentQuery).
            //ThenInclude(x => x.EquipmentQueryStatus).
            //ThenInclude(x => x.EquipmentQueryStatusNavigation);
            //relationship missing
            //ThenInclude(x => x.EquipmentQuery).
            //ThenInclude(x => x.EquipmentQueryStatus).
            //ThenInclude(x => x.EquipmentQueryStatusNavigation);
            return equipment.ToArrayAsync();

        }

        public Task<Equipment[]> GenerateTradeinReport(AuditLogViewModel model)
        {
            IQueryable<Equipment> equipment = _inf370ContextDB.Equipment.
                Include(x => x.EquipmentBrand).
                Include(x => x.EquipmentTradeInStatus).
                Include(x => x.EquipmentType).
                Include(x => x.OnboarderEquipment).
                //relationship missing
                //ThenInclude(x => x.EquipmentQuery).
                //ThenInclude(x => x.EquipmentQueryStatus).
                //ThenInclude(x => x.EquipmentQueryStatusNavigation).
                Where(x => x.EquipmentTradeUnDeadline >= model.startDate && x.EquipmentTradeUnDeadline <= model.endDate);
            return equipment.ToArrayAsync();

        }

        public Task<Equipment[]> GenerateEquipmentReport2(AuditLogViewModel model)
        {
            IQueryable<Equipment> equipment = _inf370ContextDB.Equipment.Where(x => x.EquipmentTradeUnDeadline >= model.endDate);

            IQueryable<OnboarderEquipment> equipment1Assigned = _inf370ContextDB.OnboarderEquipment;
            EquipmentViewModel2 equipmentViewModel2s = new EquipmentViewModel2();
            IQueryable<Equipment> equipment1;
            foreach (Equipment m in equipment)
            {

                OnboarderEquipment checkifAssigned = _inf370ContextDB.OnboarderEquipment.Where(x => x.EquipmentId == m.EquipmentId).FirstOrDefault();
                if (checkifAssigned != null)
                {
                    equipmentViewModel2s.equipmentAssigned.Add(m);
                }

                equipmentViewModel2s.equipmentRegistered.Add(m);

            }
            equipment1 = (IQueryable<Equipment>)equipmentViewModel2s;

            return equipment1.ToArrayAsync();



        }

        public Task<Equipment[]> GetEquiupments()
        {
            IQueryable<Equipment> equipment = _inf370ContextDB.Equipment.Include(x => x.EquipmentBrand).Include(x => x.EquipmentType);

            return equipment.ToArrayAsync();
        }
    }
}
