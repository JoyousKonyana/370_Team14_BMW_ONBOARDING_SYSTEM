using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.ViewModel
{
    public class ImportEmployeeViewModel
    {
       
        public string DepartmentDescription { get; set; }
        public string UserRoleName { get; set; }

        public string GenderDescription { get; set; }

      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public decimal? Idnumber { get; set; }
        public string EmailAddress { get; set; }
        public decimal? ContactNumber { get; set; }
        public string EmployeeJobTitle { get; set; }
        public string TitleDescription { get; set; }
        // added to add address record
        public string SuburbName { get; set; }

        public string ProvinceName { get; set; }

        public string Country { get; set; }

        public string CountryName { get; set; }

        public string StreetNumber { get; set; }

        public string StreetName { get; set; }
    }
}
