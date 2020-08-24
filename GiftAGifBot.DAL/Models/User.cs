using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftAGifBot.DAL.Models
{
    public class User : Entity
    {
        public static Guid ManagerId = Guid.Parse("D3AF975F-E57C-40D3-05C6-08D847CF3A88");
        public static User Manager = new User() { Id = Guid.Parse("D3AF975F-E57C-40D3-05C6-08D847CF3A88"), Username = "Manager", Usertag = "-1", DiscordId = "-1", Points = -1 };
        public string Username { get; set; }
        public string Usertag { get; set; }
        public string DiscordId { get; set; }
        public int Points { get; set; }

        public virtual ICollection<Endorsement> Endorsements { get; set; }

        public virtual ICollection<Gif> Gifs { get; set; }        
        
    }
}
