using AutoMapper;
using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using BMW_ONBOARDING_SYSTEM.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogController : ControllerBase
    {
        private readonly IAuditLogRepository _auditLogRepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public AuditLogController(IAuditLogRepository auditLogRepository, IMapper mapper)
        {
            _auditLogRepository = auditLogRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<CreateAuditLogViewModel>> CreateAuditLog([FromBody] CreateAuditLogViewModel model)
        {
            try
            {
                var auditLog = _mapper.Map<AuditLog>(model);
                var course = _mapper.Map<Course>(model);
                DateTime dateTime = new DateTime();
                dateTime.ToLocalTime();

                _auditLogRepository.Add(auditLog);

                if (await _auditLogRepository.SaveChangesAsync())
                {

                    var auditlog = _mapper.Map<CreateAuditLogViewModel>(model);


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
        public async Task<ActionResult<AuditLog[]>> GetAllAuditLog()
        {
            try
            {
                var result = await _auditLogRepository.GetAll();

                if (result == null) return NotFound();

                return _mapper.Map<AuditLog[]>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpGet]
        public async Task<ActionResult<AuditLog[]>> GenerateAuditReport([FromBody] AuditLogViewModel model)
        {
            try
            {
                var result = await _auditLogRepository.GenerateAuditReport(model);

                if (result == null) return NotFound();

                return _mapper.Map<AuditLog[]>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
    }
}
