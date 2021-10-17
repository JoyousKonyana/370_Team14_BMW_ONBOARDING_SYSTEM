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
    public class FaqController : ControllerBase
    {
        private readonly IFaqRepository _faqRepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public FaqController(IFaqRepository faqRepository, IMapper mapper)
        {
            _faqRepository = faqRepository;
            _mapper = mapper;
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<FaqViewModel>> CreateFaq(int userid,[FromBody] FaqViewModel model)
        {
            try
            {
                var faq = _mapper.Map<Faq>(model);

                _faqRepository.Add(faq);

                if (await _faqRepository.SaveChangesAsync())
                {
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Created Frequently asked question " + ' ' + faq.Faqdescription;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;

                    return Ok(faq);
                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }
        //[Authorize(Roles = Role.Admin + "," + Role.Onboarder + "," + Role.Manager)]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<Faq>> GetAllFaq()
        {
            try
            {
                var faqs = await _faqRepository.GetAllFaqAsync();
                return Ok(faqs);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        //[Authorize(Roles = Role.Admin)]

        [HttpPut("{id}")]
        [Route("[action]/id/{userid}")]
        public async Task<ActionResult<FaqViewModel>> UpdateFaq(int id,int userid, [FromBody] FaqViewModel updatedFaqModel)
        {
            try
            {
                var existingFaq = await _faqRepository.GetFaqIdAsync(id);

                if (existingFaq == null) return NotFound($"Could Not update the Faq please try agail later");

                _mapper.Map(updatedFaqModel, existingFaq);

                if (await _faqRepository.SaveChangesAsync())
                {
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Updated Frequently asked question " + ' ' + existingFaq.Faqdescription ;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;
                    return _mapper.Map<FaqViewModel>(existingFaq);
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
        [Route("[action]/{id}/{userid}")]
        public async Task<IActionResult> DeleteFaq(int id, int userid)
        {
            try
            {
                var existingFaq = await _faqRepository.GetFaqIdAsync(id);

                if (existingFaq == null) return NotFound();

                _faqRepository.Delete(existingFaq);

                if (await _faqRepository.SaveChangesAsync())
                {
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Deleted Frequently asked question " + ' ' + existingFaq.Faqdescription;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;
                    return Ok();
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"We could not delete this Faq");
            }

            return BadRequest();
        }
    }
}
