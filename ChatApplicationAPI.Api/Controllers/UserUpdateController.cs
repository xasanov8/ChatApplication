using ChatApplicationAPI.Application.Services.UserServices;
using ChatApplicationAPI.Domain.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplicationAPI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserUpdateController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserUpdateController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPatch("UserUpdate")]
        public async Task<ActionResult<string>> Update(int id, UserDTO model)
        {
            var result = await _userService.Update(id, model);

            return Ok(result);
        }

        [HttpPatch("UpdateFullName")]
        public async Task<ActionResult<string>> UpdateFullName(int id, string name)
        {
            var result = await _userService.UpdateFullName(id, name);

            return Ok(result);
        }

        [HttpPatch("UpdateUserName")]
        public async Task<ActionResult<string>> UpdateLogin(int id, string username)
        {
            var result = await _userService.UpdateUserName(id, username);

            return Ok(result);
        }

        [HttpPatch("UpdateName")]
        public async Task<ActionResult<string>> UpdatePassword(int id, string name)
        {
            var result = await _userService.UpdatePassword(id, name);

            return Ok(result);
        }

        /*[HttpPatch("UpdateRole")]
        public async Task<ActionResult<string>> UpdateRole(int id, string role)
        {
            var result = await _userService.UpdateRole(id, role);

            return Ok(result);
        }*/
    }
}
