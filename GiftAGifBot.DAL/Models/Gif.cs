using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftAGifBot.DAL.Models
{
    public class Gif : Entity
    {       
        public static string TargetDirectory = @"H:\Gifs For Gif Bot\";
        public int Identifier { get; set; }
        public string FileName { get; set; }
        public int DisplayCount { get; set; }
        public bool IsNSFW { get; set; }         
        public Guid CreatorId { get; set; }
        [ForeignKeyAttribute("CreatorId")]
        public User Creator { get; set; }

        public virtual ICollection<GifTag> GifTags { get; set; }

        public Gif() {
            this.DisplayCount = 0;
            this.IsNSFW = false;
        }
    }
}
