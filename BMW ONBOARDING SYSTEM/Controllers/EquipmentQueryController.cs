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
    public class EquipmentQueryController : ControllerBase
    {
        private readonly IEquipmentQueryRepository _queryRepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public EquipmentQueryController(IEquipmentQueryRepository queryRepository, IMapper mapper)
        {
            _queryRepository = queryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetQueryStatus()
        {
            try
            {
                var queryStatus = await _queryRepository.GetAllQueryStatuses();
                return Ok(queryStatus);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllQueries()
        {
            try
            {
                var queries = await _queryRepository.GetAllqueriesAsync();
                return Ok(queries);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetQuerybyid(int id)
        {
            try
            {
                var queries = await _queryRepository.GetQueryByIDAsync(id);
                return Ok(queries);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        //[Authorize(Roles = Role.Onboarder)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<EquipmentQueryViewModelcs>> ReportEquipmentQuery([FromBody] EquipmentQueryViewModelcs model)
        {
            try
            {
                var query = _mapper.Map<EquipmentQuery>(model);

                _queryRepository.Add(query);

                if (await _queryRepository.SaveChangesAsync())
                {
                    return Ok("Equipment query successfully sent");
                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("[action]/{userid}")]
        public async Task<ActionResult<EquipmentQueryViewModelcs>> CreateQueryStatus(int userid, [FromBody] EquipmentQueryStatusViewModel model)
        {
            try
            {
                var query = _mapper.Map<QueryStatus>(model);

                _queryRepository.Add(query);

                if (await _queryRepository.SaveChangesAsync())
                {
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Created Query status with description" + ' ' + query.EquipmentQueryDescription;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;
                    return Ok("Query Status Successfully created");
                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }


        //[Authorize(Roles = Role.Admin)]
        [HttpPut()]
        [Route("[action]/{userid}")]
        public async Task<ActionResult<ResolveQueryViewModel>> ResolveQuery(int userid,ResolveQueryViewModel model)
        {
            try
            {
                var existingQuery = await _queryRepository.GetQueryStatusByID(model);

                if (existingQuery == null) return NotFound($"Could Not find course with the Equipment query you are trying to Resolve");

                _mapper.Map(model, existingQuery);

                if (await _queryRepository.SaveChangesAsync())
                {
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Resolved query number" + ' ' + model.EquipmentQueryId;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;
                    return Ok("Query Successfully Resolved");
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
