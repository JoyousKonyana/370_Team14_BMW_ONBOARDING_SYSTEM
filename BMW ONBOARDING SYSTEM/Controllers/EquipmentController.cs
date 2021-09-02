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
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public EquipmentController(IEquipmentRepository equipmentRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<EquipmentViewModel>> RegisterEquipment([FromBody] EquipmentViewModel model)
        {
            try
            {
                var equipment = _mapper.Map<Equipment>(model);
                equipment.EquipmentId = 2;
                _equipmentRepository.Add(equipment);

                if (await _equipmentRepository.SaveChangesAsync())
                {
                    return Ok("Successfully registered new equipment");
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
        public async Task<ActionResult<EquipmentViewModel>> UpdateEquipment(int id, EquipmentViewModel updatedEquipmentModel)
        {
            try
            {
                var existingEquipment = await _equipmentRepository.GetEquipmentByIdAsync(id);

                if (existingEquipment == null) return NotFound($"Could Not find the equipment you are trying to update");

                _mapper.Map(updatedEquipmentModel, existingEquipment);

                if (await _equipmentRepository.SaveChangesAsync())
                {

               


                    return _mapper.Map<EquipmentViewModel>(existingEquipment);
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
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            try
            {
                var existingEquipment = await _equipmentRepository.GetEquipmentByIdAsync(id);

                if (existingEquipment == null) return NotFound();

                _equipmentRepository.Delete(existingEquipment);

                if (await _equipmentRepository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"We could not delete this Equipment");
            }

            return BadRequest();
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<EquipmentViewModel>> AssignedEquipment([FromBody] AssignedEquipmentViewModel model)
        {
            try
            {
                var equipment = _mapper.Map<OnboarderEquipment>(model);

                _equipmentRepository.Add(equipment);

                if (await _equipmentRepository.SaveChangesAsync())
                {
                    return Ok("Successfully Assigned equipment");
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
        [Route("[action]")]
        public async Task<ActionResult<EquipmentViewModel>> AssignedEquipment2([FromBody] AssignedEquipmentViewModel[] model)
        {
            try
            {
                foreach (AssignedEquipmentViewModel equip in model)
                {


                    var equipment = _mapper.Map<OnboarderEquipment>(equip);

                    _equipmentRepository.Add(equipment);

                    if (!await _equipmentRepository.SaveChangesAsync())
                    {
                        return BadRequest("The system could not assign all equipments");
                    }
                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }
        //[Authorize(Roles = Role.Onboarder)]
        [HttpPut("{id}")]
        [Route("[action]")]
        public async Task<ActionResult<AssignedEquipmentViewModel>> CheckEquipment(int id, [FromBody] AssignedEquipmentViewModel model)
        {
            try
            {

                var onboarderid = model.OnboarderId;
                var assignedEquipment = await _equipmentRepository.GetEquipmentByEquipmentOnboarderId(model.OnboarderId, model.EquipmentId);


                if (assignedEquipment == null) return NotFound($"Sorry We could not find your assigned equipment");

                _mapper.Map(model, assignedEquipment);

                if (await _equipmentRepository.SaveChangesAsync())
                {
                    return _mapper.Map<AssignedEquipmentViewModel>(assignedEquipment);
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();

        }
        //[Authorize(Roles = Role.Onboarder)]
        [HttpPut("{id}")]
        [Route("[action]/{id}")]
        public async Task<ActionResult<AssignedEquipmentViewModel>> CheckEquipment2(int id, [FromBody] AssignedEquipmentViewModel[] model)
        {
            try
            {
                foreach (AssignedEquipmentViewModel equip in model)
                {

                    var onboarderid = id;
                    var assignedEquipment = await _equipmentRepository.GetEquipmentByEquipmentOnboarderId(equip.OnboarderId, equip.EquipmentId);

                    if (assignedEquipment == null) return NotFound($"Sorry We could not find your assigned equipment");

                    _mapper.Map(equip, assignedEquipment);

                    if (!await _equipmentRepository.SaveChangesAsync())
                    {
                        return BadRequest("Sorry the system could not check all the equipment");
                    }
                }
                return Ok("Successfully checked equipment");


            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();

        }
        //[Authorize(Roles = Role.Onboarder)]
        [HttpGet("{id}")]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetAssignedEquipment(int id)
        {
            try
            {
                var equipment = await _equipmentRepository.GetEquipmentByOnboarderIDAsync(id);
                return Ok(equipment);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        //[Authorize(Roles = Role.Onboarder)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<EquipmentViewModel>> ReportEquipmentQuery([FromBody] EquipmentQueryViewModelcs model)
        {
            try
            {
                var equipment = _mapper.Map<EquipmentQuery>(model);

                _equipmentRepository.Add(equipment);

                if (await _equipmentRepository.SaveChangesAsync())
                {
                    return Ok("Your query was successfully saved");
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
        public async Task<ActionResult<Equipment[]>> GenerateAuditReport([FromBody] AuditLogViewModel model)
        {
            try
            {
                var result = await _equipmentRepository.GenerateEquipmentReport(model);

                if (result == null) return NotFound($"Could not find reports falling in the date range {model.startDate - model.endDate}");

                return _mapper.Map<Equipment[]>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<Equipment[]>> GenerateEquipmentReport([FromBody] AuditLogViewModel model)
        {
            try
            {
                var result = await _equipmentRepository.GenerateEquipmentReport2(model);

                if (result == null) return NotFound($"Could not find records falling in the date range {model.startDate - model.endDate}");

                return _mapper.Map<Equipment[]>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<Equipment[]>> GenerateTradeInReport([FromBody] AuditLogViewModel model)
        {
            try
            {
                var result = await _equipmentRepository.GenerateTradeinReport(model);

                if (result == null) return NotFound($"Could not find reports falling in the date range {model.startDate - model.endDate}");

                return _mapper.Map<Equipment[]>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }


        //This method is used to checkoutEquipment
        //[Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult<AssignedEquipmentViewModel>> EquipmentDueForTradeIn([FromBody] EquipmentCheckOutViewModel model)
        {
            try
            {

                var onboarderid = model.OnboarderId;
                var assignedEquipment = await _equipmentRepository.GetEquipmentByEquipmentOnboarderId(model.OnboarderId, model.EquipmentId);

                if (assignedEquipment == null) return NotFound($"Sorry We could not find your assigned equipment");

                _mapper.Map(model, assignedEquipment);

                if (await _equipmentRepository.SaveChangesAsync())
                {
                    return _mapper.Map<AssignedEquipmentViewModel>(assignedEquipment);
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
