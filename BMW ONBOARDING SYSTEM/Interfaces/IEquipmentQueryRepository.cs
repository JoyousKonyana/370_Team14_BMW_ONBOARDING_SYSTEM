using BMW_ONBOARDING_SYSTEM.Models;
using BMW_ONBOARDING_SYSTEM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Interfaces
{
    public interface IEquipmentQueryRepository
    {
        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        Task<EquipmentQuery[]> GetAllqueriesAsync();
        Task<EquipmentQuery> GetQueryByIDAsync(int id);
        Task<EquipmentQuery[]> GetQueryByOnboarderIDc(int id);

        Task<ResolveQueryViewModel> GetQueryStatusByID(ResolveQueryViewModel model);

        Task<QueryStatus[]> GetAllQueryStatuses();


    }
}
