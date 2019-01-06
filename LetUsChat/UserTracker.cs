using LetUsChat.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetUsChat
{
    public class UserTracker : IUserTracker
    {
        private readonly ConcurrentDictionary<String, UserInformation> onlineUserStore = new ConcurrentDictionary<String, UserInformation>();

        public async Task AddUserAsync(String connection, UserInformation userInfo)
        {
            onlineUserStore.TryAdd(connection, userInfo);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<UserInformation>> GetAllOnlineUsersAsync() => await Task.FromResult(onlineUserStore.Values.AsEnumerable());

        public async Task RemoveUserAsync(String connection)
        {
            if (onlineUserStore.TryRemove(connection, out var userInfo))
            {
                await Task.CompletedTask;
            }
        }
    }
}
