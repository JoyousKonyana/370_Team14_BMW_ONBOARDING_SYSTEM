using BMW_ONBOARDING_SYSTEM.Models;
using BMW_ONBOARDING_SYSTEM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Interfaces
{
    public interface IEquipmentRepository
    {
        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        Task<OnboarderEquipment[]> GetEquipmentByOnboarderIDAsync(int id);


        Task<Equipment> GetEquipmentByIdAsync(int id);

        Task<OnboarderEquipment> GetEquipmentByEquipmentOnboarderId(int onboarderid, int equipmentid);

        Task<Equipment[]> GenerateEquipmentReport(AuditLogViewModel model);

        Task<Equipment[]> GenerateTradeinReport(AuditLogViewModel model);
        Task<Equipment[]> GenerateEquipmentReport2(AuditLogViewModel model);

        Task<Equipment[]> GetEquiupments();


    }
}
