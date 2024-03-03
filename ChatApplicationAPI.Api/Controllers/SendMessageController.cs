using ChatApplicationAPI.Api.ExternalServices;
using ChatApplicationAPI.Application.Services.SendMessageServices;
using ChatApplicationAPI.Domain.Entities.DTOs;
using ChatApplicationAPI.Domain.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ChatApplicationAPI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _messageService;
        private readonly IWebHostEnvironment _env;
        public SendMessageController(ISendMessageService messageService, IWebHostEnvironment evn)
        {
            _messageService = messageService;
            _env = evn;
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddSendMessage(string token, [FromForm] SendMessageDTO sendMessageDTO, IFormFile path)
        {
            SendMessageExternalService service = new SendMessageExternalService(_env);

            string picturePath = await service.AddGetPath(path);

            int id = int.Parse(DecodeJwtToken(token, "sjdfnsdljldfoisdfisdfidsfbiasbfibfidfpjfhfidsfbiasdsabhfbhabibapigbpdbgajdfpjfhdsabhfbh"));

            var result = _messageService.AddSendMessage(id, sendMessageDTO, picturePath).Result;

            return Ok(result);
        }

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
