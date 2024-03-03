using ChatApplicationAPI.Api.ExternalServices;
using ChatApplicationAPI.Application.Services.UserServices;
using ChatApplicationAPI.Domain.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplicationAPI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUserService _userService;

        public UserController(IUserService userProfileService, IWebHostEnvironment env)
        {
            _userService = userProfileService;
            _env = env;
        }
    }
}
