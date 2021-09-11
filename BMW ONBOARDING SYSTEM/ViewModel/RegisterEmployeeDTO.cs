using BMW_ONBOARDING_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.ViewModel
{
    public class RegisterEmployeeDTO
    {
        public List<PostalCode> postalCodes = new List<PostalCode>();
        public List<City> cities = new List<City>();
        public List<Suburb> suburbs = new List<Suburb>();
        public List<Country> countries = new List<Country>();
        public List<Province> provinces = new List<Province>();
        public List<Department> departments = new List<Department>();
        public List<Title> titles = new List<Title>();
        public List<UserRole> userRoles = new List<UserRole>();
        public List<Gender> genders = new List<Gender>();
    }
}
