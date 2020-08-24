namespace GiftAGifBot.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gifs", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.Tags", "CreatorId", "dbo.Users");
            DropIndex("dbo.Gifs", new[] { "CreatorId" });
            DropIndex("dbo.Tags", new[] { "CreatorId" });
            RenameColumn(table: "dbo.Gifs", name: "CreatorId", newName: "Creator_Id");
            RenameColumn(table: "dbo.Tags", name: "CreatorId", newName: "Creator_Id");
            AlterColumn("dbo.Gifs", "Creator_Id", c => c.Guid());
            AlterColumn("dbo.Tags", "Creator_Id", c => c.Guid());
            CreateIndex("dbo.Gifs", "Creator_Id");
            CreateIndex("dbo.Tags", "Creator_Id");
            AddForeignKey("dbo.Gifs", "Creator_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Tags", "Creator_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "Creator_Id", "dbo.Users");
            DropForeignKey("dbo.Gifs", "Creator_Id", "dbo.Users");
            DropIndex("dbo.Tags", new[] { "Creator_Id" });
            DropIndex("dbo.Gifs", new[] { "Creator_Id" });
            AlterColumn("dbo.Tags", "Creator_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Gifs", "Creator_Id", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.Tags", name: "Creator_Id", newName: "CreatorId");
            RenameColumn(table: "dbo.Gifs", name: "Creator_Id", newName: "CreatorId");
            CreateIndex("dbo.Tags", "CreatorId");
            CreateIndex("dbo.Gifs", "CreatorId");
            AddForeignKey("dbo.Tags", "CreatorId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Gifs", "CreatorId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
