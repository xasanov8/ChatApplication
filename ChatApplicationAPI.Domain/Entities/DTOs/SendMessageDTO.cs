using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplicationAPI.Domain.Entities.DTOs
{
    public class SendMessageDTO
    {
        public int UserId { get; set; }
        public string StringMessage { get; set; }
    }
}
