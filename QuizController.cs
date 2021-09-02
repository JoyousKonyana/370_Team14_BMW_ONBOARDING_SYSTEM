using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BMW_ONBOARDING_SYSTEM.Helpers;
using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using BMW_ONBOARDING_SYSTEM.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BMW_ONBOARDING_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : Controller
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IOnboarderRepository _onboarderRepository;
        private readonly IMapper _mapper;

        public QuizController(IQuizRepository quizRepository, IOnboarderRepository onboarderRepository, IMapper mapper)
        {
            _quizRepository = quizRepository;
            _onboarderRepository = onboarderRepository;
            _mapper = mapper;
        }

        [Authorize(Role.Admin)]
        [HttpPost]
        [Route("[action]")]

        public async Task<ActionResult<QuizViewModel>> CreateQuiz([FromBody] QuizViewModel model)
        {
            try
            {
                var quiz = _mapper.Map<Quiz>(model);
                quiz.QuizId = 2;
                _quizRepository.Add(quiz);

                if (await _quizRepository.SaveChangesAsync())
                {
                    //return Ok(quiz.QuizId);

                    return Created($"/api/Quiz{quiz.QuizId}", _mapper.Map<Quiz>(quiz));
                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<AchievementTypeViewModel>> submitQuiz([FromBody] AchievementViewModel model)
        {
            try
            {
                var achievement = _mapper.Map<Achievement>(model);

                _quizRepository.Add(achievement);

                if (await _quizRepository.SaveChangesAsync())
                {
                    OnboarderCourseEnrollment onboarderEnrollment = await _onboarderRepository.
                        GetonboarderByCourseID(model.OnboarderId, model.CourseId);

                    if (onboarderEnrollment == null) return NotFound();
                    if (model.MarkAchieved > 5)
                    {
                        onboarderEnrollment.BadgeTotal += 5;
                    }
                    else
                    {
                        onboarderEnrollment.BadgeTotal = 0;
                    }

                    if (await _quizRepository.SaveChangesAsync())
                    {
                        return Ok();
                    }
                    //return Ok(quiz.QuizId);

                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<QuizViewModel>> GetQuizByLessonOutcomeID(int id)
        {
            try
            {
                var result = await _quizRepository.GetQuizByLessonOutcomeIDAsync(id);

                if (result == null) return NotFound();

                return _mapper.Map<QuizViewModel>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
    }
}
