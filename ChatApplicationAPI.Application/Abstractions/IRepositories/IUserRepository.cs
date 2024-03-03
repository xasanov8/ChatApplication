using ChatApplicationAPI.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplicationAPI.Application.Abstractions.IRepositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
