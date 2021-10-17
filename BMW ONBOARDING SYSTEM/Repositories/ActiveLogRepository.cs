//using BMW_ONBOARDING_SYSTEM.Interfaces;
//using BMW_ONBOARDING_SYSTEM.Models;
//using BMW_ONBOARDING_SYSTEM.ViewModel;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace BMW_ONBOARDING_SYSTEM.Repositories
//{
//    public class ActiveLogRepository : IActiveLogRepository
//    {
//        private readonly INF370DBContext _inf370ContextDB;

//        public ActiveLogRepository(INF370DBContext inf370ContextDB)
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

//        public Task<ActiveLog[]> GenerateActiveLogReport(AuditLogViewModel model)
//        {
//            //need to change data type of activelogtodatetime
//            IQueryable<ActiveLog> auditLogs = _inf370ContextDB.ActiveLog.
//             Where(i => i.ActiveLogLoginTimestamp == model.startDate && i.ActiveLogLoginLastActiveTimestamp <= model.endDate);
//            return auditLogs.ToArrayAsync();
//            throw new NotImplementedException();/*;*/
//        }

//        public async Task<bool> SaveChangesAsync()
//        {
//            return await _inf370ContextDB.SaveChangesAsync() > 0;
//        }
//    }
//}
