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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ChatApplicationApiDbContext context) : base(context)
        {
        }
    }
}
