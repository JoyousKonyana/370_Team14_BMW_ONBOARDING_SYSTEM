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
    public class QuestionController : ControllerBase
    {


        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        //[Authorize(Role.Admin)]
        [HttpPost]
        [Route("[action]/{userid}")]
        public async Task<ActionResult<QuestionViewModel>> Createquestion(int userid,[FromBody] QuestionViewModel model)
        {
            try
            {
                var question = _mapper.Map<Question>(model);
              
                _questionRepository.Add(question);

                if (await _questionRepository.SaveChangesAsync())
                {
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Created Question with description" + ' ' + question.QuestionDescription;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;
                    //remember to add transaction to audit log
                    return Created($"/api/Question{question.QuestionId}", _mapper.Map<QuestionViewModel>(question));
                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }

        // get question for a specific quiz
        //[Authorize(Role.Onboarder)]
        [HttpGet("{id}")]
        [Route("[action]/{id}")]
        public async Task<ActionResult<QuestionViewModel[]>> GetQuestionsForQuiz(int id)
        {
            try
            {
                Question[] result = await _questionRepository.GetQuestionByQuizIDAsync(id);

                if (result == null) return NotFound();

                return _mapper.Map<QuestionViewModel[]>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpGet("{id}")]
        [Route("[action]/{id}")]
        public async Task<ActionResult<QuestionViewModel[]>> GetQuestionsById(int id)
        {
            try
            {
                var result = await _questionRepository.GetQuestionByquestionIDAsync(id);

                if (result == null) return NotFound();

                return _mapper.Map<QuestionViewModel[]>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [Route("[action]/{id}")]
        public async Task<ActionResult<QuestionViewModel[]>> GetAllQuestions(int id)
        {
            try
            {
                var result = await _questionRepository.GetQuestionAllquestionAsync();

                if (result == null) return NotFound();

                return _mapper.Map<QuestionViewModel[]>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
        //[Authorize(Role.Admin)]
        [HttpPut("{id}")]
        [Route("[action]/{id}/{userid}")]
        public async Task<ActionResult<QuestionViewModel>> UpdateQuestion(int id,int userid, [FromBody] QuestionViewModel updatedQuestionModel)
        {
            try
            {
                var existingquestion = await _questionRepository.GetQuestionByquestionIDAsync(id);

                if (existingquestion == null) return NotFound($"Could Not find the question");

                _mapper.Map(updatedQuestionModel, existingquestion);

                if (await _questionRepository.SaveChangesAsync())
                {
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Updated Question with description" + ' ' + existingquestion.QuestionDescription;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;
                    return _mapper.Map<QuestionViewModel>(existingquestion);
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
        public async Task<IActionResult> DeleteQuestion(int id, int userid)
        {
            try
            {
                var existingQuestion = await _questionRepository.GetQuestionByquestionIDAsync(id);

                if (existingQuestion == null) return NotFound();

                _questionRepository.Delete(existingQuestion);

                if (await _questionRepository.SaveChangesAsync())
                {
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Delete Question with description" + ' ' + existingQuestion.QuestionDescription;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;
                    return Ok();
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"We could not delete the course");
            }

            return BadRequest();
        }
    }
}
