using AutoMapper;
using BMW_ONBOARDING_SYSTEM.Interfaces;
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
    public class TitleController : ControllerBase
    {

        private readonly ITitleRepository _titleRepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public TitleController(ITitleRepository titleRepository, IMapper mapper)
        {
            _titleRepository = titleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetAllTitle()
        {
            try
            {
                var titles = await _titleRepository.GetTitlestAsync();
                return Ok(titles);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
