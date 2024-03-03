using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplicationAPI.Domain.Enums
{
    public enum Permisson
    {

        CreateUser = 2,
        
        GetAll = 3,
        
        UpdateFullName = 4,
        UpdatePhoneNumber = 5,
        UpdateUserName = 6,
        UpadetPassword = 7,
        
        UpdateUserRole = 8,
        UpdateAdminRole = 9,

        SpamUser = 10,
        SpamAdmin = 11,
        
        UnSpamUser = 12,
        UnSpamAdmin = 13,
    }
}
