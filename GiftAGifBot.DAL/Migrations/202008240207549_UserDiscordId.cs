namespace GiftAGifBot.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDiscordId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "DiscordId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "DiscordId");
        }
    }
}
