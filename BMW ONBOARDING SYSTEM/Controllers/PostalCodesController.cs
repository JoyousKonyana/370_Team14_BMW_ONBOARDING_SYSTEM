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
    public class PostalCodesController : ControllerBase
    {
        private readonly IPostalCodeRepository _postalCodeRepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public PostalCodesController(IPostalCodeRepository postalCodeRepository, IMapper mapper)
        {
            _postalCodeRepository = postalCodeRepository;
            _mapper = mapper;
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<PostalCodeViewModel>> CreatePostalCode([FromBody] PostalCodeViewModel model)
        {
            try
            {
                var postalCode = _mapper.Map<PostalCode>(model);

                _postalCodeRepository.Add(postalCode);

                if (await _postalCodeRepository.SaveChangesAsync())
                {
                    return Ok("Postal code  Successfully created");
                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }

        //[Authorize(Roles = Role.Onboarder)]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllPostalCodes()
        {
            try
            {
                var postalCodes = await _postalCodeRepository.GetPostCodesAsync();
                return Ok(postalCodes);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        [Route("[action]/{id}")]
        public async Task<ActionResult<PostalCodeViewModel>> UpdatePostalCode(int id, PostalCodeViewModel updatedPostalCodeModel)
        {
            try
            {
                var existingPostalCode = await _postalCodeRepository.GetPostCodeByIdAsync(id);

                if (existingPostalCode == null) return NotFound();

                _mapper.Map(updatedPostalCodeModel, existingPostalCode);

                if (await _postalCodeRepository.SaveChangesAsync())
                {
                    return _mapper.Map<PostalCodeViewModel>(existingPostalCode);
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
        public async Task<IActionResult> DeletePostalCode(int id)
        {
            try
            {
                var existingPostalCode = await _postalCodeRepository.GetPostCodeByIdAsync(id);

                if (existingPostalCode == null) return NotFound();

                _postalCodeRepository.Delete(existingPostalCode);

                if (await _postalCodeRepository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"We could not delete the Postal code");
            }

            return BadRequest();
        }
    }
}
