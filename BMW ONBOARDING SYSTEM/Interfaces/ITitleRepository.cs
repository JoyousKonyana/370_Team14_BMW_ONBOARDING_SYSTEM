using BMW_ONBOARDING_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Interfaces
{
    public interface ITitleRepository
    {
        Task<Title[]> GetTitlestAsync();
        Task<Title> GetTitlestByNameAsync(string name);
    }
}
