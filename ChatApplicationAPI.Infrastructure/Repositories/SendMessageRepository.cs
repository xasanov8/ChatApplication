using ChatApplicationAPI.Application.Abstractions.IRepositories;
using ChatApplicationAPI.Domain.Entities.Models;
using ChatApplicationAPI.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplicationAPI.Infrastructure.Repositories
{
    public class SendMessageRepository : BaseRepository<SendMessage>, ISendMessageRepository
    {
        public SendMessageRepository(ChatApplicationApiDbContext context) : base(context)
        {
        }
    }
}
