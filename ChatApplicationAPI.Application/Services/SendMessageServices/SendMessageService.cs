using ChatApplicationAPI.Application.Abstractions.IRepositories;
using ChatApplicationAPI.Domain.Entities.DTOs;
using ChatApplicationAPI.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplicationAPI.Application.Services.SendMessageServices
{
    public class SendMessageService : ISendMessageService
    {
        private readonly ISendMessageRepository _repository;
        public SendMessageService(ISendMessageRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> AddSendMessage(int id, SendMessageDTO messageDTO, string path)
        {
            
            var model = new SendMessage()
            {
                MeId = id,
                UserId = messageDTO.UserId,
                StringMessage = messageDTO.StringMessage,
                Path = path
            };

            var result = _repository.Create(model);

            return "Accepted";
        }
        //public async Task<IEnumerable<SendMessageDTO>> GetAll

    }
}
