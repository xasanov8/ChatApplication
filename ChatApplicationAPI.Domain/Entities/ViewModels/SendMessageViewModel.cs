using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplicationAPI.Domain.Entities.ViewModels
{
    public class SendMessageViewModel
    {
        public int Id { get; set; }
        public string MeOrYou { get; set; }
        public string YouOrMe { get; set; }
        public string StringMessage { get; set; }
        public string Path { get; set; }
    }
}
