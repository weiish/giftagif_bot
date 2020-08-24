namespace GiftAGifBot.DAL
{
    using GiftAGifBot.DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GifModel : DbContext
    {
        // Your context has been configured to use a 'GifModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'GiftAGifBot.DAL.GifModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'GifModel' 
        // connection string in the application configuration file.
        public GifModel()
            : base("name=GifModel") {

        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Endorsement> Endorsements { get; set; }
        public virtual DbSet<Gif> Gifs { get; set; }
        public virtual DbSet<GifTag> GifTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }

}