using ChatApplicationAPI.Application.Services.AuthServices;
using ChatApplicationAPI.Application.Services.PasswordHash;
using ChatApplicationAPI.Application.Services.SendMessageServices;
using ChatApplicationAPI.Application.Services.UserServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplicationAPI.Application
{
    public static class ApplicationDI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ISendMessageService, SendMessageService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPasswordHashing, PasswordHashing>();

            return services;
        }
    }
}
