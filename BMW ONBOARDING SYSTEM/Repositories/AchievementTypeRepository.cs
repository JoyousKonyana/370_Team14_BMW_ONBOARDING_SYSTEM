using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class AchievementTypeRepository : IAchievementTypeRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public AchievementTypeRepository(INF370DBContext inf370ContextDB)
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

        public Task<AchievementType> GetAchievementTypeIDAsync(int achievementTypeid)
        {
            IQueryable<AchievementType> existingAchievementType = _inf370ContextDB.AchievementType.Where(id => id.AchievementTypeId == achievementTypeid);

            return existingAchievementType.FirstOrDefaultAsync();
        }

        public async Task<AchievementType[]> GetAllAchievementTypesAsync()
        {
            IQueryable<AchievementType> achievementTypes = _inf370ContextDB.AchievementType.OrderBy(c =>
           c.AchievementTypeDescription);

            return await achievementTypes.ToArrayAsync();
        }

        //public Task<AchievementType> GetAchievementTypeByNameAsync(string name)
        //{
        //    IQueryable<AchievementType> achievementType = _inf370ContextDB.AchievementType.Where(a => a.AchievementTypeDescription== name);

        //    course = course.Where(c => c.CourseName == name);

        //    return course.FirstOrDefaultAsync();
        //}

        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0; ;
        }
    }
}
