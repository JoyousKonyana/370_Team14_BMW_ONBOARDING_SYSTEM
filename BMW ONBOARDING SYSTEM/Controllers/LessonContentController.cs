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
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonContentController : ControllerBase
    {
        private readonly ILessonContentRepository _lessonContentRepository;
        private readonly IMapper _mapper;

        public LessonContentController(ILessonContentRepository lessonContentRepository, IMapper mapper)
        {
            _lessonContentRepository = lessonContentRepository;
            _mapper = mapper;
        }

      

        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<LessonContentViewModel>> UploadContentLink([FromBody] LessonContentViewModel model)
        {
            try
            {
                var lessonContent = _mapper.Map<LessonContent>(model);
                _lessonContentRepository.Add(lessonContent);

                if (await _lessonContentRepository.SaveChangesAsync())
                {
                    return Ok(lessonContent);
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
        public async Task<ActionResult<LessonContentViewModel>> AchiveLessonContent(int id, LessonContentViewModelDTO model)
        {
            try
            {
                var results = await _lessonContentRepository.GetLessonContentByIdAsync(id);

                if (results == null)
                {
                    return NotFound($"Could Not find Lesson content");
                }
                else
                {
                    results.ArchiveStatusId = 1;
                    _mapper.Map(model, results);

                }



                if (await _lessonContentRepository.SaveChangesAsync())
                {
                    return Ok("Lesson content successfully archived");
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();

        }

        [HttpPut("name")]
        [Route("[action]/{id}")]
        public async Task<ActionResult<CourseViewModel>> UpdateLessonContent(int id, LessonContentViewModelDTO updatedCourseModel)
        {
            try
            {
                var existingLessonContent = await _lessonContentRepository.GetLessonContentByIdAsync(id);

                if (existingLessonContent == null) return NotFound($"Could Not find Lesson content ");

                _mapper.Map(updatedCourseModel, existingLessonContent);

                if (await _lessonContentRepository.SaveChangesAsync())
                {
                    return _mapper.Map<CourseViewModel>(existingLessonContent);
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();

        }

        [HttpDelete("{id}")]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteLessonContent(int id)
        {
            try
            {
                var existingLessonContent = await _lessonContentRepository.GetLessonContentByIdAsync(id);

                if (existingLessonContent == null) return NotFound();

                _lessonContentRepository.Delete(existingLessonContent);

                if (await _lessonContentRepository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"We could not delete the lesson content");
            }

            return BadRequest();
        }


        //get lesson content associated with a specific lesson outcome
        //[Authorize(Roles = Role.Onboarder + "," + Role.Admin + "," + Role.Manager)]
        [HttpGet("{id}")]
        [Route("[action]/{id}")]
        public async Task<ActionResult<LessonContentViewModel[]>> GetLessonContentByLessonOutcome(int id)
        {
            try
            {
                var result = await _lessonContentRepository.GetLessonContentByLessonIDsAsync(id);

                if (result == null) return NotFound();

                return _mapper.Map<LessonContentViewModel[]>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
    }

}
