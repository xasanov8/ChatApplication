using ChatApplicationAPI.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplicationAPI.Application.Abstractions.IRepositories
{
    public interface IChatApplicationApiDbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<SendMessage> SendMessages { get; set; }

        public ValueTask<int> SaveChangesAsync(CancellationToken cancellation);

    }
}
