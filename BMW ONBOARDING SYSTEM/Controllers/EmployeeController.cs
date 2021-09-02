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
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public EmployeeController(IEmployeeRepository employeeRepository, IPostalCodeRepository postalCodeRepository,
            ICityRepository cityRepository,
            ISuburbRepository suburbRepository,
            ICountryRepository countryRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _postalCodeRepository = postalCodeRepository;
            _cityRepository = cityRepository;
            _suburbRepository = suburbRepository;
            _countryRepository = countryRepository;
        }

        //[Authorize(Roles = Role.Onboarder)]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Get()
        {
            try
            {
                RegisterEmployeeDTO registerEmployeeDTO = new RegisterEmployeeDTO();
                var postalCodes = await _postalCodeRepository.GetPostCodesAsync();
                var cities = await _cityRepository.GetCtiessAsync();
                var countries = await _countryRepository.GetCountriesAsync();
                var suburb = await _suburbRepository.GetSuburbsAsync();
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
                        user.EmployeeId = model.EmployeeId;

                        user.UserRoleID = 1;
                        user.username = model.EmailAddress;

                        //return Created($"/api/User/registerUser", user);
                        using (var httpClient = new HttpClient())
                        {
                            var company = JsonSerializer.Serialize(user);
                            var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
                            using (var response = await httpClient.PostAsync("https://localhost:44319/api/User/registerUser", requestContent))
                            {

                                string apiResponse = await response.Content.ReadAsStringAsync();

                            }
                        }
                        if (user.UserRoleID == 1)
                        {
                            Onboarder onboarder = new Onboarder();
                            onboarder.EmployeeId = employee.EmployeeId;
                            _employeeRepository.Add(onboarder);

                            if (await _employeeRepository.SaveChangesAsync())
                            {
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
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> RegisterEmployeesFromImport([FromBody] EmployeeViewModel[] model)
        {
            try
            {
                foreach (EmployeeViewModel emp in model)
                {


                    var address = _mapper.Map<Address>(emp);
                    _employeeRepository.Add(address);
                    if (await _employeeRepository.SaveChangesAsync())
                    {

                        var employee = _mapper.Map<Employee>(emp);
                        _employeeRepository.Add(employee);

                        if (await _employeeRepository.SaveChangesAsync())
                        {
                            CreateUserViewModel user = new CreateUserViewModel();
                            user.EmployeeId = emp.EmployeeId;
                            user.UserRoleID = 1;
                            user.username = emp.EmailAddress;
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
                            if (user.UserRoleID == 1)
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
                }
                return Ok();
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
        public async Task<ActionResult<EmployeeViewModel[]>> GetEmployeeById(int id)
        {
            try
            {
                var result = await _employeeRepository.GetEmployeeByID(id);

                if (result == null) return NotFound();

                return _mapper.Map<EmployeeViewModel[]>(result);
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
