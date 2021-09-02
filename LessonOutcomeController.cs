using AutoMapper;
using BMW_ONBOARDING_SYSTEM.Helpers;
using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using BMW_ONBOARDING_SYSTEM.Repositories;
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
    public class LessonOutcomeController : ControllerBase
    {

        private readonly ILessonOutcome _lessonOutcomeRepository;
        private readonly IMapper _mapper;

        public LessonOutcomeController(ILessonOutcome lessonOutcomeRepository, IMapper mapper)
        {
            _lessonOutcomeRepository = lessonOutcomeRepository;
            _mapper = mapper;
        }

        [Authorize(Role.Admin)]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllLessonOutcomes()
        {
            try
            {
                var lessonOutcomes = await _lessonOutcomeRepository.GetAllLessonOutcomesAsync();
                return Ok(lessonOutcomes);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpGet("name")]
        [Route("[action]")]
        public async Task<ActionResult<LessonOutcomeViewModel>> GetLessonOutcomeByName([FromBody] string name)
        {
            try
            {
                var result = await _lessonOutcomeRepository.GetLessonOutcomeByNameAsync(name);

                if (result == null) return NotFound();

                return _mapper.Map<LessonOutcomeViewModel>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
        [Authorize(Role.Admin + "," + Role.Onboarder)]
        [HttpGet("{id}")]
        [Route("[action]")]
        public async Task<ActionResult<LessonOutcomeViewModel>> GeLessonOutcomeByLessonId(int lessonID)
        {
            try
            {
                var result = await _lessonOutcomeRepository.GeLessonOutcomeByCourseId(lessonID);

                if (result == null) return NotFound();

                return _mapper.Map<LessonOutcomeViewModel>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [Authorize(Role.Admin)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<LessonOutcomeViewModel>> CreateLessonOutcome([FromBody] LessonOutcomeViewModel model)
        {
            try
            {
                var lessonOutcome = _mapper.Map<LessonOutcome>(model);
                _lessonOutcomeRepository.Add(lessonOutcome);

                if (await _lessonOutcomeRepository.SaveChangesAsync())
                {
                    return Created($"/api/LessonOutcome{lessonOutcome.LessonOutcomeName}", _mapper.Map<LessonOutcomeViewModel>(lessonOutcome));
                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }

        [Authorize(Role.Admin)]
        [HttpPut("name")]
        [Route("[action]")]
        public async Task<ActionResult<LessonOutcomeViewModel>> UpdateLessonOutcome(string name, LessonOutcomeViewModel updatedCourseModel)
        {
            try
            {
                var existingLessonOutcome = await _lessonOutcomeRepository.GetLessonOutcomeByNameAsync(name);

                if (existingLessonOutcome == null) return NotFound($"Could Not find course with the name: {name }");

                _mapper.Map(updatedCourseModel, existingLessonOutcome);

                if (await _lessonOutcomeRepository.SaveChangesAsync())
                {
                    return _mapper.Map<LessonOutcomeViewModel>(existingLessonOutcome);
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();

        }

        [Authorize(Role.Admin)]
        [HttpDelete("{id}")]
        [Route("[action]")]
        public async Task<IActionResult> DeleteLessonOutcome(int id)
        {
            try
            {
                var existingLessonOutcome = await _lessonOutcomeRepository.GetLessonOutcomeIdAsync(id);

                if (existingLessonOutcome == null) return NotFound();

                _lessonOutcomeRepository.Delete(existingLessonOutcome);

                if (await _lessonOutcomeRepository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"We could not delete this lesson outcome");
            }

            return BadRequest();
        }


    }
}
