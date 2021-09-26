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
    public class GenderController : ControllerBase
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public GenderController(IGenderRepository genderRepository, IMapper mapper)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;

        }
        //[Authorize(Roles = Role.Admin + "," + Role.Onboarder)]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllGenders()
        {
            try
            {
                var genders = await _genderRepository.GetAllGenderAsync();

                return Ok(genders);
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }
    }
}
