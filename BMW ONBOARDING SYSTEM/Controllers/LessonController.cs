﻿using AutoMapper;
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
    public class LessonController : ControllerBase
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public LessonController(ILessonRepository lessonRepository ,IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

       
        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<CourseViewModel>> CreateLesson([FromBody] LessonViewModel model)
        {
            try
            {
                var lesson = _mapper.Map<Lesson>(model);

                _lessonRepository.Add(lesson);

                if (await _lessonRepository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllLessons()
        {
            try
            {
                var lessons = await _lessonRepository.GetAllLessonAsync();
                return Ok(lessons);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetLessonById(int id)
        {
            try
            {
                var lesson = await _lessonRepository.GetLessonByIdAsync(id);
                return Ok(lesson);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetLessonByCourseId(int id)
        {
            try
            {
                var lesson = await _lessonRepository.GetLessonByCourseIdAsync(id);
                return Ok(lesson);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [Route("[action]/{id}")]
        public async Task<ActionResult<CourseViewModel>> UpdateLesson(int id, LessonViewModel updatedLessonModel)
        {
            try
            {
                var existingLesson = await _lessonRepository.GetLessonByIdAsync(id);

                if (existingLesson == null) return NotFound($"Could Not find Lesson ");

                _mapper.Map(updatedLessonModel, existingLesson);

                if (await _lessonRepository.SaveChangesAsync())
                {
                    return _mapper.Map<CourseViewModel>(existingLesson);
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();

        }

        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            try
            {
                var existingCourse = await _lessonRepository.GetLessonByIdAsync(id);

                if (existingCourse == null) return NotFound();

                _lessonRepository.Delete(existingCourse);

                if (await _lessonRepository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"We could not delete the Lesson");
            }

            return BadRequest();
        }

    }
}
