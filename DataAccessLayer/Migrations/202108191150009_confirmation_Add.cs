namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confirmation_Add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Managers", "Admin_Confirmations", c => c.Boolean(nullable: false));
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Managers", "Admin_Confirmation", c => c.String());
            DropColumn("dbo.Managers", "Admin_Confirmations");
        }
    }
}
