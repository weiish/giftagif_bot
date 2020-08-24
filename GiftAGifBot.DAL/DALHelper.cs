using GiftAGifBot.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftAGifBot.DAL
{
    public static class DALHelper
    {
        public static User GetManagerUser() {
            using (var gifContext = new GifModel()) {
                return gifContext.Users.First(user => user.Id == User.ManagerId);
            }
        }
    }
}
