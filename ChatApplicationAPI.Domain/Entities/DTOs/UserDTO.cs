using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplicationAPI.Domain.Entities.DTOs
{
    public class UserDTO
    {
        public string FullName { get; set; }
        public string Username { get; set; }

        [MinLength(12), MaxLength(13)]
        public string PhoneNumber { get; set; }

        [MinLength(6)]
        public string Password { get; set; }
        public string Role {  get; set; }
    }
}
