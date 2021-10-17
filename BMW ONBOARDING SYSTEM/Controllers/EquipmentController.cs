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

        //private readonly IWarrantyRepository _warrantyRepository;
        private readonly IEquipementTypeRepository _equipmentTypeRepository;
        private readonly IOnboarderRepository _onboarderRepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public EquipmentController(IEquipmentRepository equipmentRepository, IEquipementTypeRepository equipmentTypeRepository, IOnboarderRepository onboarderRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _onboarderRepository = onboarderRepository;
            _mapper = mapper;
            //_warrantyRepository = warrantyRepository;
            _equipmentTypeRepository = equipmentTypeRepository;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                RegisterEquipmentDTO equipmentDTO = new RegisterEquipmentDTO();
                //var warranty = await _warrantyRepository.GetWarrantiesAsync();
                var equipmentType = await _equipmentTypeRepository.GetAllEquipmentTypesAsync();


                foreach (var equipType in equipmentType)
                {
                    equipmentDTO.equipmentTypes.Add(equipType);
                }


                return Ok(equipmentDTO);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<Equipment[]>> GetAllEquipment()
        {
            try
            {


                var equipment = await _equipmentRepository.GetEquiupments();
                if (equipment == null) return NotFound();

                return equipment;
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("[action]/{userid}")]
        public async Task<ActionResult<EquipmentViewModel>> RegisterEquipment(int userid, [FromBody] EquipmentViewModel model)
        {
            try
            {
                var equipment = _mapper.Map<Equipment>(model);
                //equipment.EquipmentId = 2;
                _equipmentRepository.Add(equipment);

                if (await _equipmentRepository.SaveChangesAsync())
                {
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Registered equipment with" + ' ' + equipment.EquipmentSerialNumber;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;
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
        [Route("[action]/{id}/{userid}")]
        public async Task<ActionResult<EquipmentViewModel>> UpdateEquipment(int id,int userid, EquipmentViewModel updatedEquipmentModel)
        {
            try
            {
                var existingEquipment = await _equipmentRepository.GetEquipmentByIdAsync(id);

                if (existingEquipment == null) return NotFound($"Could Not find the equipment you are trying to update");

                _mapper.Map(updatedEquipmentModel, existingEquipment);

                if (await _equipmentRepository.SaveChangesAsync())
                {

                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Updated equipment with serial number" + ' ' + existingEquipment.EquipmentSerialNumber;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;



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
        [Route("[action]/{id}/{userid}")]
        public async Task<IActionResult> DeleteEquipment(int id,int userid)
        {
            try
            {
                var existingEquipment = await _equipmentRepository.GetEquipmentByIdAsync(id);

                if (existingEquipment == null) return NotFound();

                _equipmentRepository.Delete(existingEquipment);

                if (await _equipmentRepository.SaveChangesAsync())
                {

                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Deleted equipment with serial number" + ' ' + existingEquipment.EquipmentSerialNumber ;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;

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
        [Route("[action]/{userid}")]
        public async Task<ActionResult<EquipmentViewModel>> AssignedEquipment(int userid,[FromBody] AssignedEquipmentViewModel model)
        {
            try
            {
                var equipment = _mapper.Map<OnboarderEquipment>(model);
             

                _equipmentRepository.Add(equipment);

                if (await _equipmentRepository.SaveChangesAsync())
                {
                    var existingequipmemt = await _equipmentRepository.GetEquipmentByIdAsync(model.EquipmentId);
            
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Assigned equipment with serial number" + ' ' + existingequipmemt.EquipmentSerialNumber + " "+ "to onboarder with id " + " " + model.OnboarderId;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;
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
        [Route("[action]/{userid}")]
        public async Task<ActionResult<EquipmentViewModel>> AssignedEquipment2(int userid,[FromBody] AssignedEquipmentViewModel[] model)
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

                    var existingequipmemt = await _equipmentRepository.GetEquipmentByIdAsync(equip.EquipmentId);

                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Assigned equipment with serial number" + ' ' + existingequipmemt.EquipmentSerialNumber + " " + "to onboarder with id " + " " + equip.OnboarderId;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;
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
        [Route("[action]/{userid}")]
        public async Task<ActionResult<AssignedEquipmentViewModel>> CheckEquipment(int id,int userid, [FromBody] AssignedEquipmentViewModel model)
        {
            try
            {

                var onboarderid = model.OnboarderId;
                var assignedEquipment = await _equipmentRepository.GetEquipmentByEquipmentOnboarderId(model.OnboarderId, model.EquipmentId);


                if (assignedEquipment == null) return NotFound($"Sorry We could not find your assigned equipment");

                _mapper.Map(model, assignedEquipment);

                if (await _equipmentRepository.SaveChangesAsync())
                {
                    var existingequipmemt = await _equipmentRepository.GetEquipmentByIdAsync(model.EquipmentId);
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Assigned equipment with serial number" + ' ' + existingequipmemt.EquipmentSerialNumber + " " + "to onboarder with id " + " " + model.OnboarderId;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;
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
        [Route("[action]/{id}/{userid}")]
        public async Task<ActionResult<AssignedEquipmentViewModel>> CheckEquipment2(int id,int userid ,[FromBody] AssignedEquipmentViewModel[] model)
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

                    var existingequipmemt = await _equipmentRepository.GetEquipmentByIdAsync(equip.EquipmentId);
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Assigned equipment with serial number" + ' ' + existingequipmemt.EquipmentSerialNumber + " " + "to onboarder with id " + " " + equip.OnboarderId;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;
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
               OnboarderEquipment[] equipment = await _equipmentRepository.GetEquipmentByOnboarderIDAsync(id);
                return Ok(equipment);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        //[Authorize(Roles = Role.Onboarder)]
        [HttpPost]
        [Route("[action]/{userid}")]
        public async Task<ActionResult<EquipmentViewModel>> ReportEquipmentQuery(int userid, [FromBody] EquipmentQueryViewModelcs model)
        {
            try
            {
                var equipment = _mapper.Map<EquipmentQuery>(model);

                _equipmentRepository.Add(equipment);

                if (await _equipmentRepository.SaveChangesAsync())
                {
                    var existingequipmemt = await _equipmentRepository.GetEquipmentByIdAsync(model.EquipmentId);
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Submited a query for equipment with serial number" + ' ' + existingequipmemt.EquipmentSerialNumber + " " + "Currently assigned to " + " " + model.OnboarderId;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;
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
        [Route("[action]/{userid}")]
        public async Task<ActionResult<Equipment[]>> GenerateAuditReport(int userid,[FromBody] AuditLogViewModel model)
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
