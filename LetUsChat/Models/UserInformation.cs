using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetUsChat.Models
{
    public class UserInformation
    {
        public string ImageUrl { get; }
        public string ConnectionId { get; }
        public string Name { get; }

        public UserInformation(string connectionId, string name, string imageUrl)
        {
            this.ConnectionId = connectionId;
            this.Name = name;
            this.ImageUrl = imageUrl;
        }
    }
}
