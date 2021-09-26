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
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public CityController(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }


        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<CityViewModel>> CreateCity([FromBody] CityViewModel model)
        {
            try
            {
                var city = _mapper.Map<City>(model);

                _cityRepository.Add(city);

                if (await _cityRepository.SaveChangesAsync())
                {
                    return Ok("City Successfully created");
                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }
        //[Authorize(Roles = Role.Admin + "," + Role.Onboarder)]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCities()
        {
            try
            {
                var cities = await _cityRepository.GetCtiessAsync();

                return Ok(cities);
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
        public async Task<ActionResult<CityViewModel>> UpdateCity(int id, CityViewModel updatedCityModel)
        {
            try
            {
                var existingCity = await _cityRepository.GetCityyByIdAsync(id);

                if (existingCity == null) return NotFound();

                _mapper.Map(updatedCityModel, existingCity);

                if (await _cityRepository.SaveChangesAsync())
                {
                    return _mapper.Map<CityViewModel>(existingCity);
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
                var existingCities = await _cityRepository.GetCityyByIdAsync(id);

                if (existingCities == null) return NotFound();

                _cityRepository.Delete(existingCities);

                if (await _cityRepository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"We could not delete this City");
            }

            return BadRequest();
        }
    }
}

