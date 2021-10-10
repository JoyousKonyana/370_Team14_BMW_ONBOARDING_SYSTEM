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
    public class AuditRepository : IAuditLogRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public AuditRepository(INF370DBContext inf370ContextDB)
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



        public Task<AuditLog[]> GenerateAuditReport(AuditLogViewModel model)
        {
            IQueryable<AuditLog> auditLogs = _inf370ContextDB.AuditLog.
                Where(i => i.AuditLogDatestamp == model.startDate && i.AuditLogDatestamp <= model.endDate);
            return auditLogs.ToArrayAsync();

        }

        public Task<AuditLog[]> GetAll()
        {

            // need to make the relationship between user and employee to be one to many
            IQueryable<AuditLog> auditLogs = _inf370ContextDB.AuditLog.Include(x => x.User);

            return auditLogs.ToArrayAsync();

        }


        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }
    }
}
