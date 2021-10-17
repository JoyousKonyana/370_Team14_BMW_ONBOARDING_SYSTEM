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

        //[Authorize(Role.Admin)]
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
        //[Authorize(Role.Admin + "," + Role.Onboarder)]
        [HttpGet("{id}")]
        [Route("[action]/{id}")]
        public async Task<ActionResult<LessonOutcomeViewModel>> GeLessonOutcomeByLessonId(int id)
        {
            try
            {
                var result = await _lessonOutcomeRepository.GeLessonOutcomeByLessonId(id);

                if (result == null) return NotFound();

                //return _mapper.Map<LessonOutcomeViewModel>(result);
                return Ok(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        //[Authorize(Role.Admin)]
        [HttpPost]
        [Route("[action]/{userid}")]
        public async Task<ActionResult<LessonOutcomeViewModel>> CreateLessonOutcome(int userid,[FromBody] LessonOutcomeViewModel model)
        {
            try
            {
                var lessonOutcome = _mapper.Map<LessonOutcome>(model);
                _lessonOutcomeRepository.Add(lessonOutcome);

                if (await _lessonOutcomeRepository.SaveChangesAsync())
                {
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Created Lessonoutcome with name" + ' ' + lessonOutcome.LessonOutcomeName;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;

                    return Created($"/api/LessonOutcome{lessonOutcome.LessonOutcomeName}", _mapper.Map<LessonOutcomeViewModel>(lessonOutcome));
                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }

        //[Authorize(Role.Admin)]
        [HttpPut("{id}")]
        [Route("[action]/{id}/{userid}")]
        public async Task<ActionResult<LessonOutcomeViewModel>> UpdateLessonOutcome(int id,int userid, LessonOutcomeViewModel updatedCourseModel)
        {
            try
            {
                var existingLessonOutcome = await _lessonOutcomeRepository.GetLessonOutcomeIdAsync(id);

                if (existingLessonOutcome == null) return NotFound($"Could Not find this lesson outcome ");

                _mapper.Map(updatedCourseModel, existingLessonOutcome);

                if (await _lessonOutcomeRepository.SaveChangesAsync())
                {
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Updated Lessonoutcome with name" + ' ' + existingLessonOutcome.LessonOutcomeName;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;

                    return _mapper.Map<LessonOutcomeViewModel>(existingLessonOutcome);
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
        [Route("[action]/{id}/{userid}")]
        public async Task<IActionResult> DeleteLessonOutcome(int id, int userid)
        {
            try
            {
                var existingLessonOutcome = await _lessonOutcomeRepository.GetLessonOutcomeIdAsync(id);

                if (existingLessonOutcome == null) return NotFound();

                _lessonOutcomeRepository.Delete(existingLessonOutcome);

                if (await _lessonOutcomeRepository.SaveChangesAsync())
                {

                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Deleted Lessonoutcome with name" + ' ' + existingLessonOutcome.LessonOutcomeName;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;
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
