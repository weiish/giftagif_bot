namespace GiftAGifBot.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatorIdToGif : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gifs", "Creator_Id", "dbo.Users");
            DropForeignKey("dbo.Tags", "Creator_Id", "dbo.Users");
            DropIndex("dbo.Gifs", new[] { "Creator_Id" });
            DropIndex("dbo.Tags", new[] { "Creator_Id" });
            RenameColumn(table: "dbo.Gifs", name: "Creator_Id", newName: "CreatorId");
            RenameColumn(table: "dbo.Tags", name: "Creator_Id", newName: "CreatorId");
            AlterColumn("dbo.Gifs", "CreatorId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Tags", "CreatorId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Gifs", "CreatorId");
            CreateIndex("dbo.Tags", "CreatorId");
            AddForeignKey("dbo.Gifs", "CreatorId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tags", "CreatorId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.Gifs", "CreatorId", "dbo.Users");
            DropIndex("dbo.Tags", new[] { "CreatorId" });
            DropIndex("dbo.Gifs", new[] { "CreatorId" });
            AlterColumn("dbo.Tags", "CreatorId", c => c.Guid());
            AlterColumn("dbo.Gifs", "CreatorId", c => c.Guid());
            RenameColumn(table: "dbo.Tags", name: "CreatorId", newName: "Creator_Id");
            RenameColumn(table: "dbo.Gifs", name: "CreatorId", newName: "Creator_Id");
            CreateIndex("dbo.Tags", "Creator_Id");
            CreateIndex("dbo.Gifs", "Creator_Id");
            AddForeignKey("dbo.Tags", "Creator_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Gifs", "Creator_Id", "dbo.Users", "Id");
        }
    }
}
