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
    public class AchievementTypeController : ControllerBase
    {
        private readonly IAchievementTypeRepository _achievementTypeRepository;
        private readonly IMapper _mapper;

        public AchievementTypeController(IAchievementTypeRepository achievementTypeRepository, IMapper mapper)
        {
            _achievementTypeRepository = achievementTypeRepository;
            _mapper = mapper;
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<CourseViewModel>> CreateAchievementType([FromBody] AchievementTypeViewModel model)
        {
            try
            {
                var achievementType = _mapper.Map<AchievementType>(model);
                _achievementTypeRepository.Add(achievementType);

                if (await _achievementTypeRepository.SaveChangesAsync())
                {
                    return Created($"/api/course{achievementType.AchievementTypeDescription}", _mapper.Map<AchievementTypeViewModel>(achievementType));
                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllAchievemntTypes()
        {
            try
            {
                var achievementTypes = await _achievementTypeRepository.GetAllAchievementTypesAsync();
                return Ok(achievementTypes);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpGet("{id}")]
        [Route("[action]")]
        public async Task<ActionResult<AchievementTypeViewModel>> GetAchievementTypeByID(int id)
        {
            try
            {
                var result = await _achievementTypeRepository.GetAchievementTypeIDAsync(id);

                if (result == null) return NotFound();

                return _mapper.Map<AchievementTypeViewModel>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
        //[Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        [Route("[action]/{id}")]
        public async Task<ActionResult<AchievementTypeViewModel>> UpdateAchievementType(int id, AchievementTypeViewModel updatedAchievementTypeModel)
        {
            try
            {
                var existingAchievementType = await _achievementTypeRepository.GetAchievementTypeIDAsync(id);

                if (existingAchievementType == null) return NotFound($"Could Not find Achievement type");

                _mapper.Map(updatedAchievementTypeModel, existingAchievementType);

                if (await _achievementTypeRepository.SaveChangesAsync())
                {
                    return _mapper.Map<AchievementTypeViewModel>(existingAchievementType);
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
        public async Task<IActionResult> DeleteAchievementType(int id)
        {
            var name = "";
            try
            {
                var existingAchievementType = await _achievementTypeRepository.GetAchievementTypeIDAsync(id);
                name = existingAchievementType.AchievementTypeDescription;

                if (existingAchievementType == null) return NotFound();

                _achievementTypeRepository.Delete(existingAchievementType);

                if (await _achievementTypeRepository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"We could not delete Achievement: {name}");
            }

            return BadRequest();
        }


    }
}
