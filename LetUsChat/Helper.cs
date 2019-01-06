using LetUsChat.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LetUsChat
{
    public class Helper
    {
        public static UserInformation GetUserInformationFromContext(HubCallerContext context)
        {
            Claim nameIdentifierClaim = context.User.Claims.FirstOrDefault(j => j.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            var userId = nameIdentifierClaim.Value;
            var imageUrl = $"https://graph.facebook.com/{userId}/picture?type=square";
            return new UserInformation(context.ConnectionId, context.User.Identity.Name, imageUrl);
        }
    }
}
