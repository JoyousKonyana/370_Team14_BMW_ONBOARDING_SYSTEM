using AutoMapper;
using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using BMW_ONBOARDING_SYSTEM.ViewModel;
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
    public class OptionController : ControllerBase
    {
        private readonly IOption _optionRepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public OptionController(IOption optionRepository, IMapper mapper)
        {
            _optionRepository = optionRepository;
            _mapper = mapper;
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<OptionViewModel>> CreateOption([FromBody] OptionViewModel model)
        {
            try
            {
                var option = _mapper.Map<Option>(model);

                _optionRepository.Add(option);

                if (await _optionRepository.SaveChangesAsync())
                {
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Created Option with description" + ' ' + option.OptionDescription;
                    //pass user id
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = 1;

                    ////removetimefromdatabase
                    //auditLog.AuditLogTimestamp = TimeSpan.
                    _optionRepository.Add(auditLog);
                    if (await _optionRepository.SaveChangesAsync())
                    {
                        return Ok();
                    }

                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetOptionById(int id)
        {
            try
            {
                var option = await _optionRepository.GetOptionByIDAsync(id);
                return Ok(option);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        [Route("[action]/{id}")]
        public async Task<ActionResult<OptionViewModel>> UpdateOption(int id, OptionViewModel updatedOptionModel)
        {
            try
            {
                var existingOption = await _optionRepository.GetOptionByIDAsync(id);

                if (existingOption == null) return NotFound($"Could Not find option ");

                _mapper.Map(updatedOptionModel, existingOption);

                if (await _optionRepository.SaveChangesAsync())
                {
                    return _mapper.Map<OptionViewModel>(existingOption);
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();

        }

        //[Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteOption(int id)
        {
            try
            {
                var existingOption = await _optionRepository.GetOptionByIDAsync(id);

                if (existingOption == null) return NotFound();

                _optionRepository.Delete(existingOption);

                if (await _optionRepository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"We could not delete the option");
            }

            return BadRequest();
        }


    }
}
