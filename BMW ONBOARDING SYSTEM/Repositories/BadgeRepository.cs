using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class BadgeRepository : IBadgeRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public BadgeRepository(INF370DBContext inf370ContextDB)
        {
            _inf370ContextDB = inf370ContextDB;
        }
        public async Task<Badge[]> GetAllBadgesAsync()
        {
            IQueryable<Badge> result = _inf370ContextDB.Badge.Include(x => x.AchievementType);

            return await result.ToArrayAsync();
        }
    }
}
