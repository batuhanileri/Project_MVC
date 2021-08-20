namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confirmation_Add1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Managers", "Admin_Confirmation_Code1", c => c.String());
            AddColumn("dbo.Managers", "Admin_Confirmation_Code2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Managers", "Admin_Confirmation_Code2");
            DropColumn("dbo.Managers", "Admin_Confirmation_Code1");
        }
    }
}
