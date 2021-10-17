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
        private readonly IQuestionRepository _questionRepository;
        private readonly IOption _optionRepository;
        private readonly IMapper _mapper;

        public QuizController(IQuizRepository quizRepository,
            IOnboarderRepository onboarderRepository,
             IQuestionRepository questionRepository,
             IOption optionRepository
            , IMapper mapper)
        {
            _quizRepository = quizRepository;
            _onboarderRepository = onboarderRepository;
            _questionRepository = questionRepository;
            _optionRepository = optionRepository;
            _mapper = mapper;
        }

        //[Authorize(Role.Admin)]
        [HttpPost]
        [Route("[action]/{userid}")]

        public async Task<ActionResult<QuizViewModel>> CreateQuiz(int userid ,[FromBody] QuizViewModel model)
        {
            try
            {
                var quiz = _mapper.Map<Quiz>(model);

                _quizRepository.Add(quiz);

                if (await _quizRepository.SaveChangesAsync())
                {
                    //return Ok(quiz.QuizId);
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Created Quiz with description" + ' ' + quiz.QuizDescription;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;

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

        public async Task<ActionResult<QuizViewModel>> CreateQuiz2([FromBody] CreateQuizViewModel2[] model)
        {
            try
            {
                foreach (CreateQuizViewModel2 quizToquestion in model)
                {

                    var quiz = _mapper.Map<Quiz>(quizToquestion);

                    _quizRepository.Add(quiz);

                    if (await _quizRepository.SaveChangesAsync())
                    {
                        foreach (QuestionViewModel question in quizToquestion.questions)
                        {

                            var questioni = _mapper.Map<Question>(quizToquestion);
                            //assigned quiz id related to the question
                            questioni.QuizId = quiz.QuizId;

                            _questionRepository.Add(question);

                            if (await _questionRepository.SaveChangesAsync())
                            {
                                foreach (OptionsViewModel opt in quizToquestion.questionOptions)
                                {
                                    var option = _mapper.Map<Option>(opt);
                                    option.QuestionId = questioni.QuestionId;

                                    _optionRepository.Add(option);

                                }
                            }
                        }

                        //return Ok(quiz.QuizId);

                    }
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
        [Route("[action]/{id}")]
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

        [HttpGet("{id}")]
        [Route("[action]")]
        public async Task<IActionResult> GetQuizByID(int id)
        {
            try
            {
                var result = await _quizRepository.GetQuizByIDAsync(id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPut("{id}")]
        [Route("[action]/{id}/{userid}")]
        public async Task<ActionResult<QuizViewModel>> UpdateQuiz(int id,int userid ,QuizViewModel updatedQuizModel)
        {
            try
            {
                var existingQuiz = await _quizRepository.GetQuizByIDAsync(id);

                if (existingQuiz == null) return NotFound($"Could Not find quiz ");

                _mapper.Map(updatedQuizModel, existingQuiz);

                if (await _quizRepository.SaveChangesAsync())
                {
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Updated Quiz with description" + ' ' + existingQuiz.QuizDescription;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;
                    return _mapper.Map<QuizViewModel>(existingQuiz);
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();

        }
    }
}
