using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class FaqRepository : IFaqRepository
    {

        private readonly INF370DBContext _inf370ContextDB;

        public FaqRepository(INF370DBContext inf370ContextDB)
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

        public Task<Faq> GetFaqIdAsync(int Id)
        {
            IQueryable<Faq> existingFaq = _inf370ContextDB.Faq.Where(i => i.Faqid == Id);

            return existingFaq.FirstOrDefaultAsync();
        }


        public async Task<Faq[]> GetAllFaqAsync()
        {
            IQueryable<Faq> faq = _inf370ContextDB.Faq;

            return await faq.ToArrayAsync();
        }



        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }
    }
}
