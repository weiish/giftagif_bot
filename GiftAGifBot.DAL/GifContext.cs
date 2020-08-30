namespace GiftAGifBot.DAL
{
    using GiftAGifBot.DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GifContext : DbContext
    {
        // Your context has been configured to use a 'GifContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'GiftAGifBot.DAL.GifModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'GifModel' 
        // connection string in the application configuration file.
        public GifContext() : base("name=GifContext") {
            //Database.SetInitializer(new GifDBInitializer());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GifContext, GifMigrationConfiguration>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Endorsement> Endorsements { get; set; }
        public virtual DbSet<Gif> Gifs { get; set; }
        public virtual DbSet<GifTag> GifTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        //From https://www.entityframeworktutorial.net/faq/set-created-and-modified-date-in-efcore.aspx
        //Done each time something is saved
        public override int SaveChanges() {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is Entity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries) {
                ((Entity)entityEntry.Entity).ModifiedOn = DateTime.Now;

                if (entityEntry.State == EntityState.Added) {
                    ((Entity)entityEntry.Entity).CreatedOn = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }

}