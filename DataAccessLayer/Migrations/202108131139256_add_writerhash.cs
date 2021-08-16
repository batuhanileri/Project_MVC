﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_writerhash : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "PasswordSalt", c => c.Binary());
            AddColumn("dbo.Writers", "PasswordHash", c => c.Binary());
            AddColumn("dbo.Writers", "WriterTitle", c => c.String());
            DropColumn("dbo.Writers", "WriterPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WriterPassword", c => c.String());
            DropColumn("dbo.Writers", "WriterTitle");
            DropColumn("dbo.Writers", "PasswordHash");
            DropColumn("dbo.Writers", "PasswordSalt");
        }
    }
}
