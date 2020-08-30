namespace GiftAGifBot.DAL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoles : DbMigration
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
                        ModifiedOn = c.DateTime(nullable: false),
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
                        HasBeenModerated = c.Boolean(nullable: false),
                        ModeratedOn = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModeratedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gifs", t => t.GifId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.ModeratedBy_Id)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: false)
                .Index(t => t.GifId)
                .Index(t => t.TagId)
                .Index(t => t.ModeratedBy_Id);
            
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
                        ModifiedOn = c.DateTime(nullable: false),
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
                        DiscordId = c.String(),
                        Points = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatorId = c.Guid(nullable: false),
                        HasBeenModerated = c.Boolean(nullable: false),
                        ModeratedOn = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModeratedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.ModeratedBy_Id)
                .Index(t => t.CreatorId)
                .Index(t => t.ModeratedBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "ModeratedBy_Id", "dbo.Users");
            DropForeignKey("dbo.GifTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.Tags", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.GifTags", "ModeratedBy_Id", "dbo.Users");
            DropForeignKey("dbo.GifTags", "GifId", "dbo.Gifs");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Gifs", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.Endorsements", "UserId", "dbo.Users");
            DropForeignKey("dbo.Endorsements", "GifTagId", "dbo.GifTags");
            DropIndex("dbo.Tags", new[] { "ModeratedBy_Id" });
            DropIndex("dbo.Tags", new[] { "CreatorId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.Gifs", new[] { "CreatorId" });
            DropIndex("dbo.GifTags", new[] { "ModeratedBy_Id" });
            DropIndex("dbo.GifTags", new[] { "TagId" });
            DropIndex("dbo.GifTags", new[] { "GifId" });
            DropIndex("dbo.Endorsements", new[] { "UserId" });
            DropIndex("dbo.Endorsements", new[] { "GifTagId" });
            DropTable("dbo.Tags");
            DropTable("dbo.Roles");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.Gifs");
            DropTable("dbo.GifTags");
            DropTable("dbo.Endorsements");
        }
    }
}
