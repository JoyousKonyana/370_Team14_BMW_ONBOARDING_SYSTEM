using AutoMapper;
using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
//using BMW_ONBOARDING_SYSTEM.Models;
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
    public class ActiveLogController : ControllerBase
    {
        private readonly IActiveLogRepository _activeLogRepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public ActiveLogController(IActiveLogRepository activeLogRepository, IMapper mapper)
        {
            _activeLogRepository = activeLogRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<ActiveLogViewModel>> CreateActiveLog([FromBody] ActiveLogViewModel model)
        {
            try
            {
                var activeLog = _mapper.Map<ActiveLog>(model);
                //course.CourseId = 7;
                _activeLogRepository.Add(activeLog);

                if (await _activeLogRepository.SaveChangesAsync())
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
        public async Task<ActionResult<ActiveLog[]>> GenerateAuditReport([FromBody] AuditLogViewModel model)
        {
            try
            {
                var result = await _activeLogRepository.GenerateActiveLogReport(model);

                if (result == null) return NotFound();

                return _mapper.Map<ActiveLog[]>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
    }
}
