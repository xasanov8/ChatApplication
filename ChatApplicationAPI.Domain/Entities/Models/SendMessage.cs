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
        public string MeUsername { get; set; }
        public string YouUsername { get; set; }
        public string StringMessage { get; set; }
        public string Path { get; set; }
    }
}
