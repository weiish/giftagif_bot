using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftAGifBot.DAL.Models

{
    //Association Table implemented as entity
    public class GifTag : Entity {
        
        public Guid GifId { get; set; }
        [ForeignKey("GifId")]
        public Gif Gif { get; set; }

        public Guid TagId { get; set; }
        [ForeignKey("TagId")]
        public Tag Tag { get; set; }

        public virtual ICollection<Endorsement> Endorsements { get; set; }

    }
}
