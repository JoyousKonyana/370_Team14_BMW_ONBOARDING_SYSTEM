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
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeCalendarController : ControllerBase
    {
        private readonly IEmployeeCalendarRepository _employeeCalendarRepository;
        private readonly IMapper _mapper;

        public EmployeeCalendarController(IEmployeeCalendarRepository employeeCalendarRepository, IMapper mapper)
        {
            _employeeCalendarRepository = employeeCalendarRepository;
            _mapper = mapper;
        }



        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<EmployeeCalendarViewModel>> AddLink([FromBody] EmployeeCalendarViewModel model)
        {
            try
            {
                var result = _mapper.Map<EmployeeCalendar>(model);
                _employeeCalendarRepository.Add(result);

                if (await _employeeCalendarRepository.SaveChangesAsync())
                {
                    return Ok("You Teams Link success fully added");
                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }

        //[Authorize(Roles = Role.Admin + "," + Role.Onboarder)]
        [HttpDelete("{id}")]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteEmployeeCalendar(int id)
        {
            try
            {
                var result = await _employeeCalendarRepository.GetEmployeeLinkByIdAsync(id);

                if (result == null) return NotFound();

                _employeeCalendarRepository.Delete(result);

                if (await _employeeCalendarRepository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"We could not delete the Meeting Link");
            }

            return BadRequest();
        }
    }
}
