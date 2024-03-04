using ChatApplicationAPI.Api.Attributes;
using ChatApplicationAPI.Application.Services.UserServices;
using ChatApplicationAPI.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplicationAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DeleteUserController : ControllerBase
    {
        private readonly IUserService _userService;

        public DeleteUserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpDelete("DeleteUser")]
        [IdentityFilter(Permisson.DeleteUser)]
        public async Task<ActionResult<bool>> DeleteUser()
        {
            var id = Convert.ToInt32(HttpContext.User.FindFirst("Id").Value);

            var result = await _userService.DeleteUserById(id);

            return Ok(result);
        }
    }
}
