using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplicationAPI.Application.Services.PasswordHash
{
    public interface IPasswordHashing
    {
        public string Encrypt(string password, string salt);
        public bool Verify(string hash, string password, string salt);
    }
}
