namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class signup_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SignUps", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.SignUps", "LastName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.SignUps", "E_Mail", c => c.String(nullable: false));
            AlterColumn("dbo.SignUps", "Password", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SignUps", "Password", c => c.String());
            AlterColumn("dbo.SignUps", "E_Mail", c => c.String());
            DropColumn("dbo.SignUps", "LastName");
            DropColumn("dbo.SignUps", "FirstName");
        }
    }
}
