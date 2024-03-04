using ChatApplicationAPI.Api.Attributes;
using ChatApplicationAPI.Application.Services.UserServices;
using ChatApplicationAPI.Domain.Entities.DTOs;
using ChatApplicationAPI.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ChatApplicationAPI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserUpdateController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserUpdateController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPatch("UserUpdate")]
        [IdentityFilter(Permisson.UserUpdate)]
        public async Task<ActionResult<string>> Update([FromForm] UserDTO model)
        {
            var id = Convert.ToInt32(HttpContext.User.FindFirst("Id").Value);

            var result = await _userService.Update(id, model);

            return Ok(result);
        }

        [HttpPatch("UpdateFullName")]
        [IdentityFilter(Permisson.UpdateFullName)]
        public async Task<ActionResult<string>> UpdateFullName(string name)
        {
            var id = Convert.ToInt32(HttpContext.User.FindFirst("Id").Value);

            var result = await _userService.UpdateFullName(id, name);

            return Ok(result);
        }

        [HttpPatch("UpdateUserName")]
        [IdentityFilter(Permisson.UpdateUserName)]
        public async Task<ActionResult<string>> UpdateLogin(string username)
        {
            var id = Convert.ToInt32(HttpContext.User.FindFirst("Id").Value);
            var result = await _userService.UpdateUserName(id, username);

            return Ok(result);
        }

        [HttpPatch("UpdatePassword")]
        [IdentityFilter(Permisson.UpdatePassword)]
        public async Task<ActionResult<string>> UpdatePassword(string password)
        {
            var id = Convert.ToInt32(HttpContext.User.FindFirst("Id").Value);
            var result = await _userService.UpdatePassword(id, password);

            return Ok(result);
        }

        [HttpPatch("UpdatePhoneNumber")]
        [IdentityFilter(Permisson.UpdatePhoneNumber)]
        public async Task<ActionResult<string>> UpdatePhoneNumber(string phoneNumber)
        {
            var id = Convert.ToInt32(HttpContext.User.FindFirst("Id").Value);
            var result = await _userService.UpdatePhoneNumber(id, phoneNumber);

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
