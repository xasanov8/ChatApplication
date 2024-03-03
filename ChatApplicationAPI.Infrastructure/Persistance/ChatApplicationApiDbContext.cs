using ChatApplicationAPI.Application.Abstractions.IRepositories;
using ChatApplicationAPI.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplicationAPI.Infrastructure.Persistance
{
    public class ChatApplicationApiDbContext : DbContext
    {
        public ChatApplicationApiDbContext(DbContextOptions<ChatApplicationApiDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SendMessage> SendMessages { get; set; }
    }
}
