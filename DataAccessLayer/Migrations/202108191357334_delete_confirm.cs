namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_confirm : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Managers", "Admin_Confirmations");
            DropColumn("dbo.Managers", "Admin_Confirmation_Code1");
            DropColumn("dbo.Managers", "Admin_Confirmation_Code2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Managers", "Admin_Confirmation_Code2", c => c.String());
            AddColumn("dbo.Managers", "Admin_Confirmation_Code1", c => c.String());
            AddColumn("dbo.Managers", "Admin_Confirmations", c => c.Boolean(nullable: false));
        }
    }
}
