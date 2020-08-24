namespace GiftAGifBot.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutoPopulateDateTimes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Endorsements", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.GifTags", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Gifs", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tags", "ModifiedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tags", "ModifiedOn");
            DropColumn("dbo.Users", "ModifiedOn");
            DropColumn("dbo.Gifs", "ModifiedOn");
            DropColumn("dbo.GifTags", "ModifiedOn");
            DropColumn("dbo.Endorsements", "ModifiedOn");
        }
    }
}
