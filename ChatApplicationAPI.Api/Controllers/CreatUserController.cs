using ChatApplicationAPI.Api.Attributes;
using ChatApplicationAPI.Application.Services.UserServices;
using ChatApplicationAPI.Domain.Entities.DTOs;
using ChatApplicationAPI.Domain.Entities.Models;
using ChatApplicationAPI.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplicationAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CreatUserController : ControllerBase
    {
        private readonly IUserService _userService;
        public CreatUserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [IdentityFilter(Permisson.CreateUser)]
        public async Task<ActionResult<string>> CreateUser([FromForm] UserDTO userDTO)
        {
            var result = await _userService.Create(userDTO);    

            return Ok(result);
        }
    }
}
