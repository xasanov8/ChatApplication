using ChatApplicationAPI.Api.Attributes;
using ChatApplicationAPI.Api.ExternalServices;
using ChatApplicationAPI.Application.Services.UserServices;
using ChatApplicationAPI.Domain.Entities.DTOs;
using ChatApplicationAPI.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplicationAPI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserReadController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUserService _userService;

        public UserReadController(IUserService userProfileService, IWebHostEnvironment env)
        {
            _userService = userProfileService;
            _env = env;
        }

        [HttpGet("GetAll")]
        [IdentityFilter(Permisson.GetAllUsers)]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            var result = await _userService.GetAll();

            return Ok(result);
        }
    }
}
