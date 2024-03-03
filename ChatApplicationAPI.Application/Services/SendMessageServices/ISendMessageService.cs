using ChatApplicationAPI.Domain.Entities.DTOs;
using ChatApplicationAPI.Domain.Entities.Models;
using ChatApplicationAPI.Domain.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplicationAPI.Application.Services.SendMessageServices
{
    public interface ISendMessageService
    {
        public Task<string> AddSendMessage(int id, SendMessageDTO messageDTO, string path);
        public Task<IEnumerable<SendMessage>> GetAllChats(int id, string YouUsername);
        /*public Task<IEnumerable<SendMessage>> GetAllContacts();
        public Task<IEnumerable<SendMessage>> GetByUserIdMessages(int id);*/
    }
}
