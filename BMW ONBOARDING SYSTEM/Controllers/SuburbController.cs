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
    public class SuburbController : ControllerBase
    {
        private readonly ISuburbRepository _suburbRepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public SuburbController(ISuburbRepository suburbRepository, IMapper mapper)
        {
            _suburbRepository = suburbRepository;
            _mapper = mapper;
        }
        //[Authorize(Role.Onboarder + "," + Role.Admin)]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllSuburbs()
        {
            try
            {
                var suburbs = await _suburbRepository.GetSuburbsAsync();
                return Ok(suburbs);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<SuburbViewModel>> CreateSuburb([FromBody] SuburbViewModel model)
        {
            try
            {
                var suburb = _mapper.Map<Suburb>(model);

                _suburbRepository.Add(suburb);

                if (await _suburbRepository.SaveChangesAsync())
                {
                    return Ok("Suburb Successfully created");
                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        [Route("[action]/{id}")]
        public async Task<ActionResult<SuburbViewModel>> UpdateSuburb(int id, [FromBody] SuburbViewModel updatedSuburbModel)
        {
            try
            {
                var existingSuburb = await _suburbRepository.GetSubburbByIdAsync(id);

                if (existingSuburb == null) return NotFound();

                _mapper.Map(updatedSuburbModel, existingSuburb);

                if (await _suburbRepository.SaveChangesAsync())
                {
                    return _mapper.Map<SuburbViewModel>(existingSuburb);
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
        public async Task<IActionResult> DeleteCity(int id)
        {
            try
            {
                var existingSuburb = await _suburbRepository.GetSubburbByIdAsync(id);

                if (existingSuburb == null) return NotFound();

                _suburbRepository.Delete(existingSuburb);

                if (await _suburbRepository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"We could not delete the Suburb");
            }

            return BadRequest();
        }
    }
}
