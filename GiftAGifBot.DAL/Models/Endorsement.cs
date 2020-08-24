using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftAGifBot.DAL.Models
{
    //Association table between GifTag and User
    public class Endorsement : Entity
    {
        public Guid GifTagId { get; set; }
        [ForeignKey("GifTagId")]
        public GifTag GifTag { get; set; }
        
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        
    }
}
