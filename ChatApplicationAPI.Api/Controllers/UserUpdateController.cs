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
        public async Task<ActionResult<string>> Update(int id, UserDTO model)
        {
            var result = await _userService.Update(id, model);

            return Ok(result);
        }

        [HttpPatch("UpdateFullName")]
        [IdentityFilter(Permisson.UpdateFullName)]
        public async Task<ActionResult<string>> UpdateFullName(string token, string name)
        {
            int id = int.Parse(DecodeJwtToken(token, "sjdfnsdljldfoisdfisdfidsfbiasbfibfidfpjfhfidsfbiasdsabhfbhabibapigbpdbgajdfpjfhdsabhfbh"));
            var result = await _userService.UpdateFullName(id, name);

            return Ok(result);
        }

        [HttpPatch("UpdateUserName")]
        [IdentityFilter(Permisson.UpdateUserName)]
        public async Task<ActionResult<string>> UpdateLogin(string token, string username)
        {
            int id = int.Parse(DecodeJwtToken(token, "sjdfnsdljldfoisdfisdfidsfbiasbfibfidfpjfhfidsfbiasdsabhfbhabibapigbpdbgajdfpjfhdsabhfbh"));
            var result = await _userService.UpdateUserName(id, username);

            return Ok(result);
        }

        [HttpPatch("UpdatePassword")]
        [IdentityFilter(Permisson.UpdatePassword)]
        public async Task<ActionResult<string>> UpdatePassword(string token, string password)
        {
            int id = int.Parse(DecodeJwtToken(token, "sjdfnsdljldfoisdfisdfidsfbiasbfibfidfpjfhfidsfbiasdsabhfbhabibapigbpdbgajdfpjfhdsabhfbh"));
            var result = await _userService.UpdatePassword(id, password);

            return Ok(result);
        }

        [HttpPatch("UpdatePhoneNumber")]
        [IdentityFilter(Permisson.UpdatePhoneNumber)]
        public async Task<ActionResult<string>> UpdatePhoneNumber(string token, string phoneNumber)
        {
            int id = int.Parse(DecodeJwtToken(token, "sjdfnsdljldfoisdfisdfidsfbiasbfibfidfpjfhfidsfbiasdsabhfbhabibapigbpdbgajdfpjfhdsabhfbh"));
            var result = await _userService.UpdatePhoneNumber(id, phoneNumber);

            return Ok(result);
        }

        /*[HttpPatch("UpdateRole")]
        public async Task<ActionResult<string>> UpdateRole(int id, string role)
        {
            var result = await _userService.UpdateRole(id, role);

            return Ok(result);
        }*/

        private string DecodeJwtToken(string token, string secretKey)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(secretKey);

                // Configure Token Validation Parameters
                var tokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                // Decode Token
                var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);

                // Extract ID from claims
                var id = claimsPrincipal.FindFirst("Id").Value;

                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error decoding JWT token: " + ex.Message);
                return null;
            }
        }
    }
}
