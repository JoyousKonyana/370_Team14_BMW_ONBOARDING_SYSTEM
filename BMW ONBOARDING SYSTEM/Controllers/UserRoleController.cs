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
    public class UserRoleController : ControllerBase
    {

        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public UserRoleController(IUserRoleRepository userRoleRepository, IUserRepository userRepository, IMapper mapper)
        {
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }


        [HttpGet("name")]
        [Route("[action]")]
        public async Task<ActionResult<UserRoleViewModel>> GetUserRoleByName([FromBody] string name)
        {
            try
            {
                var result = await _userRoleRepository.GetUserRoleByname(name);

                if (result == null) return NotFound();

                return _mapper.Map<UserRoleViewModel>(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<UserRoleViewModel>> CreateUserRole([FromBody] UserRoleViewModel model)
        {
            try
            {
                var userRole = _mapper.Map<UserRole>(model);
                userRole.UserRoleId = 1;
                _userRoleRepository.Add(userRole);

                if (await _userRoleRepository.SaveChangesAsync())
                {
                    return Created($"/api/UserRole{userRole.UserRoleName}", _mapper.Map<UserRoleViewModel>(userRole));
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
        public async Task<ActionResult<UserRoleViewModel>> UpdateUserRole(int id, UserRoleViewModel updatedModel)
        {
            try
            {
                var existinguserRole = await _userRoleRepository.GetUserRoleByid(id);

                if (existinguserRole == null) return NotFound($"Could Not find this User Role");

                _mapper.Map(updatedModel, existinguserRole);

                if (await _userRoleRepository.SaveChangesAsync())
                {
                    return _mapper.Map<UserRoleViewModel>(existinguserRole);
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();

        }
        //[Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult<UserRoleViewModel>> AssignedUserRole([FromBody] AssignedUserRoleViewModel model)
        {
            try
            {
                var existinguser = await _userRepository.GetUserByIdAsync(model.User_ID);

                if (existinguser == null) return NotFound($"We could not update this  users User Role please try again");

                //_mapper.Map(updatedModel, existinguserRole);
                existinguser.UserRoleId = model.UserRoleID;

                if (await _userRoleRepository.SaveChangesAsync())
                {
                    return Ok("SuccessFully assigned user Role");
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
        public async Task<IActionResult> DeleteUserRole(int id)
        {
            try
            {
                var existingUserRole = await _userRoleRepository.GetUserRoleByid(id);

                if (existingUserRole == null) return NotFound();

                _userRoleRepository.Delete(existingUserRole);

                if (await _userRoleRepository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"We could not delete this User Role");
            }

            return BadRequest();
        }


        //[Authorize(Roles = Role.Admin)]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllUserRoles()
        {
            try
            {
                var existingUserRoles = await _userRoleRepository.getAllUserRoles();

                if (existingUserRoles == null) return NotFound();

                _userRoleRepository.Delete(existingUserRoles);

                if (await _userRoleRepository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"We could not get the userRoles");
            }

            return BadRequest();
        }

    }
}
