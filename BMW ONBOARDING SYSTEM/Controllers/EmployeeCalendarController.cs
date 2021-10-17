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
        [Route("[action]/{userid}")]
        public async Task<ActionResult<EmployeeCalendarViewModel>> AddLink(int userid, [FromBody] EmployeeCalendarViewModel model)
        {
            try
            {
                var result = _mapper.Map<EmployeeCalendar>(model);
                _employeeCalendarRepository.Add(result);

                if (await _employeeCalendarRepository.SaveChangesAsync())
                {
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Added employee link" + ' ' + result.EmployeeCalendarLink;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;
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
        [Route("[action]/{id}/{userid}")]
        public async Task<IActionResult> DeleteEmployeeCalendar(int id, int userid)
        {
            try
            {
                var result = await _employeeCalendarRepository.GetEmployeeLinkByIdAsync(id);

                if (result == null) return NotFound();

                _employeeCalendarRepository.Delete(result);

                if (await _employeeCalendarRepository.SaveChangesAsync())
                {
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Deleted employee calendar link" + ' ' + result.EmployeeCalendarLink;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;
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
