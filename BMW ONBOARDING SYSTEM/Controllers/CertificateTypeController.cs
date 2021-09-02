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
//    public class CertificateTypeController : ControllerBase
//    {
//        private readonly ICertificateTypeRepository _certificateTypeRepository;
//        private readonly IMapper _mapper;

//        public CertificateTypeController(ICertificateTypeRepository certificateTypeRepository, IMapper mapper)
//        {
//            _certificateTypeRepository = certificateTypeRepository;
//            _mapper = mapper;
//        }

//        [Authorize(Roles = Role.Admin)]
//        [HttpPost]
//        [Route("[action]")]
//        public async Task<ActionResult<CertificateTypeViewModel>> CreateCertificateType([FromBody] CertificateTypeViewModel model)
//        {
//            try
//            {
//                var certificateType = _mapper.Map<CertificateType>(model);
//                _certificateTypeRepository.Add(certificateType);

//                if (await _certificateTypeRepository.SaveChangesAsync())
//                {
//                    return Created($"/api/CertificateType{certificateType.CertificateTypeId}", certificateType.CertificateTypeId);
//                }
//            }
//            catch (Exception)
//            {

//                BadRequest();
//            }
//            return BadRequest();
//        }

//        //This function will be used by the User with administrative access
//        [HttpGet]
//        [Route("[action]")]
//        public async Task<IActionResult> GetAllCertificateTypes()
//        {
//            try
//            {
//                var results = await _certificateTypeRepository.GetAllCertificateTypesAsync();
//                return Ok(results);
//            }
//            catch (Exception)
//            {

//                return BadRequest();
//            }
//        }
//        [Authorize(Roles = Role.Admin)]
//        [Route("[action]")]
//        [HttpGet("{id}")]
//        public async Task<ActionResult<CertificateTypeViewModel>> GetCertificateTypeByID(int id)
//        {
//            try
//            {
//                var result = await _certificateTypeRepository.GetCertificateTypeByIdAsync(id);

//                if (result == null) return NotFound();

//                return _mapper.Map<CertificateTypeViewModel>(result);
//            }
//            catch (Exception)
//            {

//                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
//            }
//        }
//        [Authorize(Roles = Role.Admin)]
//        [HttpDelete("{id}")]
//        [Route("[action]")]
//        public async Task<IActionResult> DeleteCertificateType(int id)
//        {
//            try
//            {
//                var existingCertificateType = await _certificateTypeRepository.GetCertificateTypeByIdAsync(id);

//                if (existingCertificateType == null) return NotFound();

//                _certificateTypeRepository.Delete(existingCertificateType);

//                if (await _certificateTypeRepository.SaveChangesAsync())
//                {
//                    return Ok();
//                }
//            }
//            catch (Exception)
//            {

//                return this.StatusCode(StatusCodes.Status500InternalServerError, $"We could not delete this certificate type");
//            }

//            return BadRequest();
//        }


//    }
//}
