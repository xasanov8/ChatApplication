using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChatApplicationAPI.Domain.Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }

        [MinLength(13), MaxLength(13)]
        public string PhoneNumber { get; set; }

        [MinLength(6)]
        public string Password { get; set; }

        [JsonIgnore]
        public string Salt { get; set; }
        public string Role { get; set; }
        public bool Spam { get; set; } = false;
    }
}
