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
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceRepository _provinceRepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public ProvinceController(IProvinceRepository provinceRepository, IMapper mapper)
        {
            _provinceRepository = provinceRepository;
            _mapper = mapper;
        }

        [Authorize(Role.Admin)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<ProvinceViewModel>> CreateProvince([FromBody] ProvinceViewModel model)
        {
            try
            {
                var province = _mapper.Map<Province>(model);

                _provinceRepository.Add(province);

                if (await _provinceRepository.SaveChangesAsync())
                {
                    return Ok("Province successfully Created");
                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }

        //[Authorize(Role.Onboarder + "," + Role.Admin)]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllProvinces()
        {
            try
            {
                var provinces = await _provinceRepository.GetProvincesAsync();
                return Ok(provinces);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        //[Authorize(Role.Admin)]
        [HttpPut("{id}")]
        [Route("[action]/{id}")]
        public async Task<ActionResult<ProvinceViewModel>> EditProvince(int id, ProvinceViewModel updatedProvinceModel)
        {
            try
            {
                var existingProvice = await _provinceRepository.GetProvinceByIdAsync(id);

                if (existingProvice == null) return NotFound($"Could Not find Province, please try again");

                _mapper.Map(updatedProvinceModel, existingProvice);

                if (await _provinceRepository.SaveChangesAsync())
                {
                    return _mapper.Map<ProvinceViewModel>(existingProvice);
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();

        }
        //[Authorize(Role.Admin)]
        [HttpDelete("{id}")]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteProvince(int id)
        {
            try
            {
                var existingProvince = await _provinceRepository.GetProvinceByIdAsync(id);

                if (existingProvince == null) return NotFound();

                _provinceRepository.Delete(existingProvince);

                if (await _provinceRepository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"We could not delete the Province");
            }

            return BadRequest();
        }

    }
}
