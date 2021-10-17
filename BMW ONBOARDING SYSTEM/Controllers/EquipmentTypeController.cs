using AutoMapper;
using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using BMW_ONBOARDING_SYSTEM.Repositories;
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
    public class EquipmentTypeController : ControllerBase
    {
        private readonly IEquipementTypeRepository _equipmentTypepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public EquipmentTypeController(IEquipementTypeRepository equipmentTypepository, IMapper mapper)
        {
            _equipmentTypepository = equipmentTypepository;
            _mapper = mapper;
        }

        //[Authorize(Roles = Role.Admin + "," + Role.Onboarder)]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<EquipmentType>> GetAllEquipmentTypes()
        {
            try
            {
                var types = await _equipmentTypepository.GetAllEquipmentTypesAsync();

                return Ok(types);
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }
    }
}
