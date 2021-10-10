using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class TitleRepository : ITitleRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public TitleRepository(INF370DBContext inf370ContextDB)
        {
            _inf370ContextDB = inf370ContextDB;
        }
        public async Task<Title[]> GetTitlestAsync()
        {
            IQueryable<Title> result = _inf370ContextDB.Title;

            return await result.ToArrayAsync();
        }

        public async Task<Title> GetTitlestByNameAsync(string name)
        {
            IQueryable<Title> result = _inf370ContextDB.Title.Where(x => x.TitleDescription == name);

            return await result.FirstOrDefaultAsync();
        }
    }
}
