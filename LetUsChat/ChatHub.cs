using LetUsChat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetUsChat
{
    [Authorize]
    public class ChatHub : Hub
    {
        private IUserTracker userTracker;

        public ChatHub(IUserTracker userTracker)
        {
            this.userTracker = userTracker;
        }

        public async Task<IEnumerable<UserInformation>> GetOnlineUsersAsync()
        {
            return await userTracker.GetAllOnlineUsersAsync();
        }

        public override async Task OnConnectedAsync()
        {
            var user = Helper.GetUserInformationFromContext(Context);
            await userTracker.AddUserAsync(Context.ConnectionId, user);
            await Clients.All.SendAsync("UsersJoined", new UserInformation[] { user });
            await Clients.All.SendAsync("SetUsersOnline", await GetOnlineUsersAsync());

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var user = Helper.GetUserInformationFromContext(Context);
            await userTracker.RemoveUserAsync(Context.ConnectionId);
            await Clients.All.SendAsync("UsersLeft", new UserInformation[] { user });
            await Clients.All.SendAsync("SetUsersOnline", await GetOnlineUsersAsync());

            await base.OnDisconnectedAsync(exception);
        }

        public async Task Send(String message)
        {
            var user = Helper.GetUserInformationFromContext(Context);
            await Clients.All.SendAsync("Send", user.Name, message, user.ImageUrl);
        }
    }
}
