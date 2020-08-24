namespace GiftAGifBot.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Endorsements",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GifTagId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GifTags", t => t.GifTagId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.GifTagId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.GifTags",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GifId = c.Guid(nullable: false),
                        TagId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gifs", t => t.GifId, cascadeDelete: false)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: false)
                .Index(t => t.GifId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Gifs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Identifier = c.Int(nullable: false),
                        FileName = c.String(),
                        DisplayCount = c.Int(nullable: false),
                        IsNSFW = c.Boolean(nullable: false),
                        CreatorId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorId, cascadeDelete: false)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(),
                        Usertag = c.String(),
                        Points = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatorId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorId, cascadeDelete: false)
                .Index(t => t.CreatorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GifTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.Tags", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.GifTags", "GifId", "dbo.Gifs");
            DropForeignKey("dbo.Gifs", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.Endorsements", "UserId", "dbo.Users");
            DropForeignKey("dbo.Endorsements", "GifTagId", "dbo.GifTags");
            DropIndex("dbo.Tags", new[] { "CreatorId" });
            DropIndex("dbo.Gifs", new[] { "CreatorId" });
            DropIndex("dbo.GifTags", new[] { "TagId" });
            DropIndex("dbo.GifTags", new[] { "GifId" });
            DropIndex("dbo.Endorsements", new[] { "UserId" });
            DropIndex("dbo.Endorsements", new[] { "GifTagId" });
            DropTable("dbo.Tags");
            DropTable("dbo.Users");
            DropTable("dbo.Gifs");
            DropTable("dbo.GifTags");
            DropTable("dbo.Endorsements");
        }
    }
}
