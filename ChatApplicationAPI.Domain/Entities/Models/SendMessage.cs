using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplicationAPI.Domain.Entities.Models
{
    public class SendMessage
    {
        public int Id { get; set; }
        public int MeId { get; set; }
        public int UserId { get; set; }
        public string StringMessage { get; set; }
        public string Path { get; set; }
    }
}
