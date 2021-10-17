//using AutoMapper;
//using BMW_ONBOARDING_SYSTEM.Helpers;
//using BMW_ONBOARDING_SYSTEM.Interfaces;
//using BMW_ONBOARDING_SYSTEM.Models;
//using BMW_ONBOARDING_SYSTEM.ViewModel;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace BMW_ONBOARDING_SYSTEM.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class WarrantyController : ControllerBase
//    {
//        private readonly IWarrantyRepository _warrantyRepository;
//        private readonly IMapper _mapper;
//        // functionality not implemented yet
//        // create a quiz together with a question
//        public WarrantyController(IWarrantyRepository warrantyRepository, IMapper mapper)
//        {
//            _warrantyRepository = warrantyRepository;
//            _mapper = mapper;
//        }
//        //[Authorize(Roles = Role.Admin)]
//        [HttpPost]
//        [Route("[action]")]
//        public async Task<ActionResult<WarrantyViewModel>> CreateWarranty([FromBody] WarrantyViewModel model)
//        {
//            try
//            {
//                var warranty = _mapper.Map<Warranty>(model);

//                _warrantyRepository.Add(warranty);

//                if (await _warrantyRepository.SaveChangesAsync())
//                {
//                    return Ok("Successfully Created Warranty");
//                }
//            }
//            catch (Exception)
//            {

//                BadRequest();
//            }
//            return BadRequest();
//        }

//        [HttpGet]
//        [Route("[action]")]
//        public async Task<IActionResult> Get()
//        {
//            try
//            {
//                var warranties = await _warrantyRepository.GetWarrantiesAsync();
//                return Ok(warranties);
//            }
//            catch (Exception)
//            {

//                return BadRequest();
//            }
//        }
//        //[Authorize(Roles = Role.Admin)]
//        [HttpPut("{id}")]
//        [Route("[action]/{id}")]
//        public async Task<ActionResult<WarrantyViewModel>> EditWarranty(int id, [FromBody] WarrantyViewModel updatedWarrantyModel)
//        {
//            try
//            {
//                var existingWarranty = await _warrantyRepository.GetWarrantyByIdAsync(id);

//                if (existingWarranty == null) return NotFound($"Could Not find warranty");

//                _mapper.Map(updatedWarrantyModel, existingWarranty);

//                if (await _warrantyRepository.SaveChangesAsync())
//                {
//                    return _mapper.Map<WarrantyViewModel>(existingWarranty);
//                }
//            }
//            catch (Exception)
//            {

//                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
//            }

//            return BadRequest();

//        }
//        //[Authorize(Roles = Role.Admin)]
//        [HttpDelete("{id}")]
//        [Route("[action]/{id}")]
//        public async Task<IActionResult> DeleteWarranty(int id)
//        {
//            try
//            {
//                var existingWarranty = await _warrantyRepository.GetWarrantyByIdAsync(id);

//                if (existingWarranty == null) return NotFound();

//                _warrantyRepository.Delete(existingWarranty);

//                if (await _warrantyRepository.SaveChangesAsync())
//                {
//                    return Ok();
//                }
//            }
//            catch (Exception)
//            {

//                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure we could not delete the Warranty");
//            }

//            return BadRequest();
//        }
//    }
//}
