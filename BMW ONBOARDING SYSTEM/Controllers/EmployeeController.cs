using AutoMapper;
using BMW_ONBOARDING_SYSTEM.Helpers;
using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;

using BMW_ONBOARDING_SYSTEM.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPostalCodeRepository _postalCodeRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ISuburbRepository _suburbRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ITitleRepository _titleRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly IProvinceRepository _provinceRepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public EmployeeController(IEmployeeRepository employeeRepository, IPostalCodeRepository postalCodeRepository,
            ICityRepository cityRepository,
            ISuburbRepository suburbRepository,
            ICountryRepository countryRepository,
            ITitleRepository titleRepository,
             IDepartmentRepository departmentRepository,
              IUserRoleRepository userRoleRepository,
              IGenderRepository genderRepository,
               IProvinceRepository provinceRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _postalCodeRepository = postalCodeRepository;
            _cityRepository = cityRepository;
            _suburbRepository = suburbRepository;
            _countryRepository = countryRepository;
            _titleRepository = titleRepository;
            _departmentRepository = departmentRepository;
            _userRoleRepository = userRoleRepository;
            _genderRepository = genderRepository;
            _provinceRepository = provinceRepository;
        }

        //[Authorize(Roles = Role.Onboarder)]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                RegisterEmployeeDTO registerEmployeeDTO = new RegisterEmployeeDTO();

                var postalCodes = await _postalCodeRepository.GetPostCodesAsync();
                var cities = await _cityRepository.GetCtiessAsync();
                var countries = await _countryRepository.GetCountriesAsync();
                var suburb = await _suburbRepository.GetSuburbsAsync();
                var title = await _titleRepository.GetTitlestAsync();
                var department = await _departmentRepository.GetDepartmentAsync();
                var gender = await _genderRepository.GetAllGenderAsync();
                var userRoles = await _userRoleRepository.getAllUserRoles();
                var provice = await _provinceRepository.GetProvincesAsync();
                foreach (var m in postalCodes)
                {
                    registerEmployeeDTO.postalCodes.Add(m);
                }

                foreach (var m in cities)
                {
                    registerEmployeeDTO.cities.Add(m);
                }
                foreach (var m in countries)
                {
                    registerEmployeeDTO.countries.Add(m);
                }

                foreach (var m in suburb)
                {
                    registerEmployeeDTO.suburbs.Add(m);
                }

                foreach (var m in title)
                {
                    registerEmployeeDTO.titles.Add(m);
                }

                foreach (var m in department)
                {
                    registerEmployeeDTO.departments.Add(m);
                }
                foreach (var m in gender)
                {
                    registerEmployeeDTO.genders.Add(m);
                }
                foreach (var m in userRoles)
                {
                    registerEmployeeDTO.userRoles.Add(m);
                }
                foreach (var m in provice)
                {
                    registerEmployeeDTO.provinces.Add(m);
                }

                return Ok(registerEmployeeDTO);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> RegisterEmployee([FromBody] EmployeeViewModel model)
        {
            try
            
            
            
            {
                var address = _mapper.Map<Address>(model);
                _employeeRepository.Add(address);
                if (await _employeeRepository.SaveChangesAsync())
                {


                    var employee = _mapper.Map<Employee>(model);
                    _employeeRepository.Add(employee);


                    if (await _employeeRepository.SaveChangesAsync())
                    {
                        CreateUserViewModel user = new CreateUserViewModel();
                        user.EmployeeId = employee.EmployeeId;

                        user.UserRoleId = model.UserRoleID;
                        user.Username = employee.EmailAddress;

                        //return Created($"/api/User/registerUser", user);
                        using (var httpClient = new HttpClient())
                        {
                            var userData = JsonSerializer.Serialize(user);
                            var requestContent = new StringContent(userData, Encoding.UTF8, "application/json");
                            using (var response = await httpClient.PostAsync("https://localhost:44319/api/User/registerUser", requestContent))
                            {

                                string apiResponse = await response.Content.ReadAsStringAsync();

                            }
                        }

                        if (user.UserRoleId == 1)
                        {
                            Onboarder onboarder = new Onboarder();
                            onboarder.EmployeeId = employee.EmployeeId;
                            _employeeRepository.Add(onboarder);

                            if (await _employeeRepository.SaveChangesAsync())
                            {
                                SendSmsViewModel sendSms = new SendSmsViewModel();
                                sendSms.to = Convert.ToString(model.ContactNumber.ToString().Trim());

                                using (var httpClient = new HttpClient())
                                {
                                    var smsData = JsonSerializer.Serialize(sendSms);
                                    var requestContent = new StringContent(smsData, Encoding.UTF8, "application/json");
                                    using (var response = await httpClient.PostAsync("https://localhost:44319/api/Sms/SendSMS", requestContent))
                                    {

                                        string apiResponse = await response.Content.ReadAsStringAsync();

                                    }
                                }
                                return Ok();
                            }
                        }


                    }

                    //var createAuditLog = _mapper.Map<CreateAuditLogViewModel>(model);

                    //using (var httpClient = new HttpClient())
                    //{
                    //    var company = JsonSerializer.Serialize(createAuditLog);
                    //    var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                    //    using (var response = await httpClient.PostAsync("https://localhost:44319/api/AuditLog/CreateAuditLog", requestContent))
                    //    {
                    //        string apiResponse = await response.Content.ReadAsStringAsync();

                    //    }
                    //}

                    return Ok();
                    //var responce = addonboarder(employee.EmployeeId);
                    //return RedirectToAction("registerUser", "User", user);
                    //return Ok();
                    //return Created($"/api/course{course.CourseName}", _mapper.Map<CourseViewModel>(course));
                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }

        //[Authorize(Roles = Role.Admin)]
        //[HttpPost]
        //[Route("[action]")]
        //public async Task<ActionResult> RegisterEmployeesFromImport([FromBody] EmployeeViewModel[] model)
        //{
        //    try
        //    {
        //        foreach (EmployeeViewModel emp in model)
        //        {


        //            var address = _mapper.Map<Address>(emp);
        //            _employeeRepository.Add(address);
        //            if (await _employeeRepository.SaveChangesAsync())
        //            {

        //                var employee = _mapper.Map<Employee>(emp);
        //                _employeeRepository.Add(employee);

        //                if (await _employeeRepository.SaveChangesAsync())
        //                {
        //                    CreateUserViewModel user = new CreateUserViewModel();
        //                    user.EmployeeId = employee.EmployeeId;
        //                    user.UserRoleId = emp.UserRoleID;
        //                    user.Username = employee.EmailAddress;
        //                    //return Created($"/api/User/registerUser", user);
        //                    using (var httpClient = new HttpClient())
        //                    {
        //                        var serializedUser = JsonSerializer.Serialize(user);
        //                        var requestContent = new StringContent(serializedUser, Encoding.UTF8, "application/json");
        //                        using (var response = await httpClient.PostAsync("https://localhost:44319/api/User/registerUser", requestContent))
        //                        {

        //                            string apiResponse = await response.Content.ReadAsStringAsync();

        //                        }
        //                    }
        //                    if (user.UserRoleId == 1)
        //                    {
        //                        Onboarder onboarder = new Onboarder();
        //                        onboarder.EmployeeId = employee.EmployeeId;
        //                        _employeeRepository.Add(onboarder);

        //                        if (!await _employeeRepository.SaveChangesAsync())
        //                        {
        //                            return BadRequest("Sorry we could not register All the users check the List of users to see where the system failed");
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {

        //        BadRequest();
        //    }
        //    return BadRequest();
        //}

        [HttpDelete("{id}")]
        [Route("[action]/{id}/{userid}")]
        public async Task<IActionResult> DeleteEmployee(int id, int userid)
        {
            try
            {
                var existingemp = await _employeeRepository.GetEmployeeByID(id);

                if (existingemp == null) return NotFound();

                _employeeRepository.Delete(existingemp);

                if (await _employeeRepository.SaveChangesAsync())
                {

                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Deleted employe with name " + ' ' + existingemp.FirstName;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;
                    return Ok();
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"We could not delete the course");
            }
            return BadRequest();
        }
            [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> EmployeesFromImport([FromBody] ImportEmployeeViewModel[] model)
        {
            try
            {
                int counter = 0;
                foreach (ImportEmployeeViewModel emp in model)
                {

                    var suburb = await _suburbRepository.GetSuburbByName(emp.SuburbName);
                    if (suburb == null) return BadRequest();
                    var city = await _cityRepository.GetCityyByNameAsync(emp.Country);
                    if (city == null) return BadRequest();
                    var country = await _countryRepository.GetCountryByNameAsync(emp.CountryName);
                    if (country == null) return BadRequest();
                    var province = await _provinceRepository.GetProvinceNameAsync(emp.ProvinceName);
                    if (province == null) return BadRequest();
                    Address address = new Address();
                    address.SuburbId = suburb.SuburbId;
                    address.CityId = city.CityId;
                    address.CountryId = country.CountryId;
                    address.ProvinceId = province.ProvinceId;
                    address.StreetName = emp.StreetName;
                    address.StreetNumber = emp.StreetNumber;
                    //var address = _mapper.Map<Address>(emp);
                    _employeeRepository.Add(address);
                    if (await _employeeRepository.SaveChangesAsync())
                    {
                        var gender = await _genderRepository.GetGenderByName(emp.GenderDescription);
                        if (gender == null) return BadRequest();
                        var department = await _departmentRepository.GetDepartmentByName(emp.DepartmentDescription);
                        if (department == null) return BadRequest();
                        var title = await _titleRepository.GetTitlestByNameAsync(emp.TitleDescription);
                        if (title == null) return BadRequest();
                        Employee employee = new Employee();
                        employee.TitleId = title.TitleId;
                        employee.DepartmentId = department.DepatmentId;
                        employee.GenderId = gender.GenderId;
                        employee.AddressId = address.AddressId;
                        employee.FirstName = emp.FirstName;
                        employee.LastName = emp.LastName;
                        employee.MiddleName = emp.MiddleName;
                        employee.Idnumber = emp.Idnumber;
                        employee.EmailAddress = emp.EmailAddress;
                        employee.ContactNumber = emp.ContactNumber;
                        employee.EmployeeJobTitle = emp.EmployeeJobTitle;

                        //var employee = _mapper.Map<Employee>(emp);
                        _employeeRepository.Add(employee);

                        if (await _employeeRepository.SaveChangesAsync())
                        {
                            var userrole = await _userRoleRepository.GetUserRoleByname(emp.UserRoleName);
                            if (userrole == null) return BadRequest();
                            CreateUserViewModel user = new CreateUserViewModel();
                            user.EmployeeId = employee.EmployeeId;
                            user.UserRoleId = userrole.UserRoleId;
                            user.Username = employee.EmailAddress;
                            //return Created($"/api/User/registerUser", user);
                            using (var httpClient = new HttpClient())
                            {
                                var serializedUser = JsonSerializer.Serialize(user);
                                var requestContent = new StringContent(serializedUser, Encoding.UTF8, "application/json");
                                using (var response = await httpClient.PostAsync("https://localhost:44319/api/User/registerUser", requestContent))
                                {

                                    string apiResponse = await response.Content.ReadAsStringAsync();

                                }
                            }
                            if (user.UserRoleId == 1)
                            {
                                Onboarder onboarder = new Onboarder();
                                onboarder.EmployeeId = employee.EmployeeId;
                                _employeeRepository.Add(onboarder);

                                if (!await _employeeRepository.SaveChangesAsync())
                                {
                                    return BadRequest("Sorry we could not register All the users check the List of users to see where the system failed");
                                }

                            }
                        }
                    }
                    counter++;
                }
                return Ok(counter);
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }
        //[Authorize(Roles = Role.Admin)]
        [HttpGet("name")]
        [Route("[action]")]
        public async Task<ActionResult<EmployeeViewModel[]>> GetEmployeeByName([FromBody] string name)
        {
            try
            {
                var result = await _employeeRepository.GetEmployeeByNameAsync(name);

                if (result == null) return NotFound();

                return _mapper.Map<EmployeeViewModel[]>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var result = await _employeeRepository.GetEmployeeByID(id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<Employee[]>> GetAllEmployees()
        {
            try
            {
                var result = await _employeeRepository.GetAllEmployeesAsync();

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }



        //[Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        [Route("[action]/{id}")]
        public async Task<ActionResult<EmployeeViewModel>> UpdateEmployee(int id, EmployeeViewModel updatedEmployeeModel)
        {
            try
            {
                var existingEmployee = await _employeeRepository.GetEmployeeByID(id);

                if (existingEmployee == null) return NotFound($"Could Not find Employee");

                _mapper.Map(updatedEmployeeModel, existingEmployee);

                if (await _employeeRepository.SaveChangesAsync())
                {
                    return _mapper.Map<EmployeeViewModel>(existingEmployee);
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();

        }

    }
}
