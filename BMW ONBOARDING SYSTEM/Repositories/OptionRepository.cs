using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class OptionRepository : IOption
    {
        private readonly INF370DBContext _inf370ContextDB;

        public OptionRepository(INF370DBContext inf370ContextDB)
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

        public Task<Option> GetOptionByIDAsync(int optionID)
        {
            IQueryable<Option> options = _inf370ContextDB.Option.Where(x => x.OptionId == optionID);

            return options.FirstOrDefaultAsync();

        }

        public Task<Option[]> GetOptionByQuestionIDAsync(int questionId)
        {
            IQueryable<Option> options = _inf370ContextDB.Option.Where(x => x.QuestionId == questionId);

            return options.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }
    }
}
