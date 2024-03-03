using ChatApplicationAPI.Domain.Entities.DTOs;
using ChatApplicationAPI.Domain.Entities.Models;
using ChatApplicationAPI.Domain.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplicationAPI.Application.Services.UserServices
{
    public interface IUserService
    {
        public Task<string> Create(UserDTO userDTO);

        public Task<IEnumerable<UserViewModel>> GetAll();
        public Task<IEnumerable<User>> GetByAll(Expression<Func<User, bool>> expression);
        //public Task<IEnumerable<UserViewModel>> GetByRole(string role);
        public Task<User> GetByAny(Expression<Func<User, bool>> expression);

        public Task<bool> DeleteById(int id);
        public Task<bool> Delete(Expression<Func<User, bool>> expression);

        public Task<string> Update(int Id, UserDTO userDTO);
        public Task<string> UpdateFullName(int id, string name);
        public Task<string> UpdatePhoneNumber(int id, string phoneNumber);
        public Task<string> UpdatePassword(int id, string password);    
        public Task<string> UpdateUserName(int id, string username);
    }
}
