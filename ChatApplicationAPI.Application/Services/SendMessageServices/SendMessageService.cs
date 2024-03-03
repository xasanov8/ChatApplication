using ChatApplicationAPI.Application.Abstractions.IRepositories;
using ChatApplicationAPI.Domain.Entities.DTOs;
using ChatApplicationAPI.Domain.Entities.Models;
using ChatApplicationAPI.Domain.Entities.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        private readonly IUserRepository _userRepository;
        public SendMessageService(ISendMessageRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }
        public async Task<string> AddSendMessage(int id, SendMessageDTO messageDTO, string path)
        {
            if (messageDTO != null)
            {
                if (_userRepository.GetByAny(x => x.Id == id).Result != null && _userRepository.GetByAny(x => x.Username == messageDTO.YouUsername).Result != null) 
                {          
                    var model = new SendMessage()
                    {
                        MeUsername = _userRepository.GetByAny(x => x.Id == id).Result.Username,
                        YouUsername = messageDTO.YouUsername,
                        StringMessage = messageDTO.StringMessage,
                        Path = path
                    };

                    var result = await _repository.Create(model);

                    return "Accepted";
                }
                return "Error Model Colums";
            }
            return "Model null";
        }
        
        public async Task<IEnumerable<SendMessage>> GetAllChats(int id, string YouUsername)
        {
            var MeUserName = await _userRepository.GetByAny(x => x.Id == id);

            var messages = await _repository.GetByAll(x =>
            (x.MeUsername == MeUserName.Username && x.YouUsername == YouUsername) ||
            (x.MeUsername == YouUsername && x.YouUsername == MeUserName.Username)
                );

            if (messages != null)
            {
                return messages;
            }
            return null;
        }

    }
}
