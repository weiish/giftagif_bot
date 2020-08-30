﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftAGifBot.DAL.Models
{
    public class UserRole : Entity
    {
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User{ get; set; }

        public Guid RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role{ get; set; }

    }
}
