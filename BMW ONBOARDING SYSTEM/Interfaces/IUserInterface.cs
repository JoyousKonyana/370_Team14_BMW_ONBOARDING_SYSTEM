using BMW_ONBOARDING_SYSTEM.Models;
using BMW_ONBOARDING_SYSTEM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Interfaces
{
    public interface IUserInterface
    {
        User Authenticate(Authenticate userDetails);

        User GetById(int id);

        User Create(CreateUserViewModel model);

        void Delete(int id);
    }
}
