using ChatApplicationAPI.Application.Services.AuthServices;
using ChatApplicationAPI.Domain.Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplicationAPI.Api.Identity
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseLogin>> Login([FromForm] RequestLogin model)
        {
            var result = await _authService.GenerateToken(model);

            return Ok(result);
        }
    }
}
