using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftAGifBot.DAL.Models
{
    public class Tag : Entity
    {
        public string Name { get; set; }

        public Guid CreatorId { get; set; }

        [ForeignKeyAttribute("CreatorId")]
        public User Creator { get; set; }

        public virtual ICollection<GifTag> GifTags { get; set; }
    }
}
