using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplicationAPI.Domain.Enums
{
    public enum Permisson
    {
        DeleteUser = 1,
        AddSendMessage,
        GetAllMessage,
        UpdateSendMessage,
        DeleteSendMessage,
        GetAllUsers,
        UserUpdate,
        UpdateFullName,
        UpdateUserName,
        UpdatePassword,
        UpdatePhoneNumber,
    }
}
