using ChatApplicationAPI.Api.ExternalServices;
using ChatApplicationAPI.Application.Services.SendMessageServices;
using ChatApplicationAPI.Domain.Entities.DTOs;
using ChatApplicationAPI.Domain.Entities.Models;
using ChatApplicationAPI.Domain.Entities.ViewModels;
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
        
        public async Task<ActionResult<string>> AddSendMessage(string token, [FromForm] SendMessageDTO sendMessageDTO,  IFormFile? path)
        {
            string picturePath;
            if (path != null)
            {
                SendMessageExternalService service = new SendMessageExternalService(_env);

                picturePath = await service.AddGetPath(path);
            }
            else
            {
                picturePath = null;
            }

            int id = int.Parse(DecodeJwtToken(token, "sjdfnsdljldfoisdfisdfidsfbiasbfibfidfpjfhfidsfbiasdsabhfbhabibapigbpdbgajdfpjfhdsabhfbh"));

            var result = _messageService.AddSendMessage(id, sendMessageDTO, picturePath).Result;

            return Ok(result);
        }


        [HttpGet]
        public async Task<IEnumerable<SendMessage>> GetAllMessages(string token, string YouUsername)
        {
            int id = int.Parse(DecodeJwtToken(token, "sjdfnsdljldfoisdfisdfidsfbiasbfibfidfpjfhfidsfbiasdsabhfbhabibapigbpdbgajdfpjfhdsabhfbh"));

            var result = await _messageService.GetAllChats(id, YouUsername);

            return result;
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateSendMessage(string token, [FromForm] SendMessageDTO messageDTO, IFormFile? path, int MessageId)
        {
            string picturePath;
            if (path != null)
            {
                SendMessageExternalService service = new SendMessageExternalService(_env);

                picturePath = await service.AddGetPath(path);
            }
            else
            {
                picturePath = null;
            }

            int id = int.Parse(DecodeJwtToken(token, "sjdfnsdljldfoisdfisdfidsfbiasbfibfidfpjfhfidsfbiasdsabhfbhabibapigbpdbgajdfpjfhdsabhfbh"));

            var result = _messageService.UpdateSendMessage(id, messageDTO, picturePath, MessageId).Result;

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteSendMessage(string token, string YouUsername, int MessageId)
        {
            int id = int.Parse(DecodeJwtToken(token, "sjdfnsdljldfoisdfisdfidsfbiasbfibfidfpjfhfidsfbiasdsabhfbhabibapigbpdbgajdfpjfhdsabhfbh"));

            return await _messageService.DeleteSendMessage(id, YouUsername, MessageId);
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
