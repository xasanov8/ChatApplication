using ChatApplicationAPI.Application.Abstractions.IRepositories;
using ChatApplicationAPI.Domain.Entities.DTOs;
using ChatApplicationAPI.Domain.Entities.Models;
using ChatApplicationAPI.Domain.Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChatApplicationAPI.Application.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Create(UserDTO userDTO)
        {
            if (_userRepository.GetByAny(x => x.Username == userDTO.Username).Result == null && _userRepository.GetByAny(x => x.PhoneNumber == userDTO.PhoneNumber).Result == null)
            {
                var model = new User()
                {
                    FullName = userDTO.FullName,
                    PhoneNumber = userDTO.PhoneNumber,
                    Password = userDTO.Password,
                    Username = userDTO.Username,
                    Role = userDTO.Role,
                };

                await _userRepository.Create(model);

                return "Save NEW User";
            }
            return "Error";
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var users = await _userRepository.GetAll();

            var result = users.Select(model => new UserViewModel
            {
                FullName = model.FullName,
                Username = model.Username,
                Role = model.Role,
            });

            return result;
        }

        public async Task<IEnumerable<User>> GetByAll(Expression<Func<User, bool>> expression)
        {
            var result = await _userRepository.GetByAll(expression);

            return result;
        }

        public async Task<User> GetByAny(Expression<Func<User, bool>> expression)
        {
            var result = await _userRepository.GetByAny(expression);

            return result;
        }

        public async Task<bool> DeleteById(int id)
        {
            var result = await _userRepository.Delete(x => x.Id == id);

            return result;
        }

        public async Task<bool> Delete(Expression<Func<User, bool>> expression)
        {
            var result = await _userRepository.Delete(expression);

            return result;
        }


        ////////// ########     updates      ############
        ///
        public async Task<string> Update(int Id, UserDTO userDTO)
        {
            var result = await _userRepository.GetByAny(x => x.Id == Id);
            if (result != null)
            {
                var check = await _userRepository.GetByAny(x => x.PhoneNumber == userDTO.PhoneNumber);
                if (check == null)
                {
                    if ((await _userRepository.GetByAny(x => x.Username == userDTO.Username)) == null)
                    {
                        result.FullName = userDTO.FullName;
                        result.PhoneNumber = userDTO.PhoneNumber;
                        result.Username = userDTO.Username;
                        result.Password = userDTO.Password;
                        result.Role = userDTO.Role;

                        await _userRepository.Update(result);

                        return "Update User";
                    }
                    return "Dublicate UserName";
                }
                return "Dublicate PhoneNumber"; 
            }
            return "No such id exists";
        }

        public async Task<string> UpdateFullName(int id, string name)
        {
            var result = await _userRepository.GetByAny(x => x.Id == id);
            if (result != null)
            {
                result.FullName = name;
                await _userRepository.Update(result);
                return "Update FullName";
            }
            return "No such id exists";
        }

        public async Task<string> UpdatePhoneNumber(int id, string phoneNumber)
        {
            var result = await _userRepository.GetByAny(x => x.Id == id);

            if (result != null)
            {
                if (_userRepository.GetByAny(x => x.PhoneNumber == phoneNumber).Result == null)
                {
                    result.PhoneNumber = phoneNumber;
                    await _userRepository.Update(result);
                    return "Update PhoneNumber";
                }
                return "Drop PhoneNumber";
            }
            return "No such id exists";
        }

        public async Task<string> UpdatePassword(int id, string password)
        {
            var result = await _userRepository.GetByAny(x => x.Id == id);
            if (result != null)
            {
                result.Password = password;
                await _userRepository.Update(result);
                return "Update Password";
            }
            return "No such id exists";
        }

        public async Task<string> UpdateUserName(int id, string username)
        {
            var result = await _userRepository.GetByAny(x=> x.Id == id);
            if (result != null)
            {
                if (_userRepository.GetByAny(x => x.Username == username).Result == null)
                {
                    result.Username = username;
                    await _userRepository.Update(result);
                    return "Update UserName";
                }
                return "Drop UserName";
            }
            return "No such id exists";
        }

        /*public async Task<string> UpdateRole(int id, string role)
        {
            
        }*/


        // ######################### SPAMS ##########################

        /*public async Task<string> SpamUser(int id, string role)
        {

        }

        public async Task<string> SpamAdmin(int id, string role)
        {

        }

        public async Task<string> UnSpamUser(int id, string role)
        {

        }

        public async Task<string> UnSpamAdmin(int id, string role)
        {

        }*/
    }
}
