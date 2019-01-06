using LetUsChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace LetUsChat
{
    public interface IUserTracker
    {
        Task<IEnumerable<UserInformation>> GetAllOnlineUsersAsync();
        Task AddUserAsync(String connection, UserInformation userInfo);
        Task RemoveUserAsync(String connection);
    }
}
