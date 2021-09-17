using AutoMapper;
using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
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
    public class EquipmentBrandController : ControllerBase
    {
        private readonly IEquipmentBrandRepository _brandepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public EquipmentBrandController(IEquipmentBrandRepository brandepository, IMapper mapper)
        {
            _brandepository = brandepository;
            _mapper = mapper;
        }

        //[Authorize(Roles = Role.Admin + "," + Role.Onboarder)]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<EquipmentBrand>> GetAllEquipmentBrands()
        {
            try
            {
                var brands = await _brandepository.GetAllEquipmentBrandsAsync();

                return Ok(brands);
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }
    }
}
