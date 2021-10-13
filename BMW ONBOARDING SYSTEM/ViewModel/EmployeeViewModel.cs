using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.ViewModel
{
    public class EmployeeViewModel
    {
        //public int EmployeeId { get; set; }
        public int? DepartmentId { get; set; }
        public int? UserRoleID { get; set; }
        
        public int? GenderId { get; set; }
        public int? AddressId { get; set; }
        public int? EmployeeCalendarId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public decimal? Idnumber { get; set; }
        public string EmailAddress { get; set; }
        public decimal? ContactNumber { get; set; }
        public string EmployeeJobTitle { get; set; }
        public int? TitleId { get; set; }

     // added to add address record
        public int SuburbId { get; set; }
      
        public int ProvinceId { get; set; }
   
        public int CityId { get; set; }
    
        public int CountryId { get; set; }

        public string StreetNumber { get; set; }

        public string StreetName { get; set; }
    }
}
