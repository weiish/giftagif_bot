﻿namespace GiftAGifBot.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncrementIdentifier : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Gifs", "Identifier", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Gifs", "Identifier", c => c.Int(nullable: false));
        }
    }
}
