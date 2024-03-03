using ChatApplicationAPI.Application.Abstractions.IRepositories;
using ChatApplicationAPI.Domain.Entities.Models;
using ChatApplicationAPI.Infrastructure.Persistance;
using ChatApplicationAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApplicationAPI.Infrastructure
{
    public static class InfrastuctureDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChatApplicationApiDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("FutureProjectsConnectionString"));
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISendMessageRepository, SendMessageRepository>();


            return services;
        }
    }
}
