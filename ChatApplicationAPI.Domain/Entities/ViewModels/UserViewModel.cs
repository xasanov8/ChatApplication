using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplicationAPI.Domain.Entities.ViewModels
{
    public class UserViewModel
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
