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
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCountries()
        {
            try
            {
                var countries = await _countryRepository.GetCountriesAsync();
                return Ok(countries);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<CountryViewModel>> CreateCountry([FromBody] CountryViewModel model)
        {
            try
            {
                var country = _mapper.Map<Country>(model);

                _countryRepository.Add(country);

                if (await _countryRepository.SaveChangesAsync())
                {
                    return Ok("Country Successfully created");
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
        public async Task<ActionResult<CountryViewModel>> UpdateCountry(int id, CountryViewModel updatedCountryModel)
        {
            try
            {
                var existingCountry = await _countryRepository.GetCountryByIdAsync(id);

                if (existingCountry == null) return NotFound();

                _mapper.Map(updatedCountryModel, existingCountry);

                if (await _countryRepository.SaveChangesAsync())
                {
                    return _mapper.Map<CountryViewModel>(existingCountry);
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();

        }

        //[Authorize(Roles = Role.Admin)]
        [Route("[action]/{id}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            try
            {
                var existingCountry = await _countryRepository.GetCountryByIdAsync(id);

                if (existingCountry == null) return NotFound();

                _countryRepository.Delete(existingCountry);

                if (await _countryRepository.SaveChangesAsync())
                {
                    return Ok("Country Successfully deleted");
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"We could not delete this country");
            }

            return BadRequest();
        }
    }
}
