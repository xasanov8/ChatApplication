using ChatApplicationAPI.Api.Attributes;
using ChatApplicationAPI.Api.ExternalServices;
using ChatApplicationAPI.Application.Services.SendMessageServices;
using ChatApplicationAPI.Domain.Entities.DTOs;
using ChatApplicationAPI.Domain.Entities.Models;
using ChatApplicationAPI.Domain.Entities.ViewModels;
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
        [IdentityFilter(Permisson.AddSendMessage)]
        public async Task<ActionResult<string>> AddSendMessage([FromForm] SendMessageDTO sendMessageDTO,  IFormFile? path)
        {
            var id = Convert.ToInt32(HttpContext.User.FindFirst("Id").Value);

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


            var result = _messageService.AddSendMessage(id, sendMessageDTO, picturePath).Result;

            return Ok(result);
        }


        [HttpGet]
        [IdentityFilter(Permisson.GetAllMessage)]
        public async Task<IEnumerable<SendMessage>> GetAllMessages(string YouUsername)
        {
            var id = Convert.ToInt32(HttpContext.User.FindFirst("Id").Value);

            var result = await _messageService.GetAllChats(id, YouUsername);

            return result;
        }

        [HttpPut]
        [IdentityFilter(Permisson.UpdateSendMessage)]
        public async Task<ActionResult<string>> UpdateSendMessage([FromForm] SendMessageDTO messageDTO, IFormFile? path, int MessageId)
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

            var id = Convert.ToInt32(HttpContext.User.FindFirst("Id").Value);

            var result = _messageService.UpdateSendMessage(id, messageDTO, picturePath, MessageId).Result;

            return Ok(result);
        }

        [HttpDelete]
        [IdentityFilter(Permisson.DeleteSendMessage)]
        public async Task<ActionResult<bool>> DeleteSendMessage(string YouUsername, int MessageId)
        {
            var id = Convert.ToInt32(HttpContext.User.FindFirst("Id").Value);

            return await _messageService.DeleteSendMessage(id, YouUsername, MessageId);
        }
    }
}
