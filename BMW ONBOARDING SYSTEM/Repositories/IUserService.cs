using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using BMW_ONBOARDING_SYSTEM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class IUserService : IUserInterface
    {
        private INF370DBContext _inf370DBcontext;

        public IUserService(INF370DBContext inf370DBcontext)
        {
            _inf370DBcontext = inf370DBcontext;
        }
        //public User Authenticate(UserAuthorisationViewModelcs user)
        //{


        //    if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
        //        return null;

        //    var user = _context.Users.SingleOrDefault(x => x.Username == username);

        //    // check if username exists
        //    if (user == null)
        //        return null;

        //    // check if password is correct
        //    if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        //        return null;

        //    // authentication successful
        //    return user;

        //}

        public User Create(CreateUserViewModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }








        public User Authenticate(Authenticate userDetails)
        {
            throw new NotImplementedException();
        }
    }
}
