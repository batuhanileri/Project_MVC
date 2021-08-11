namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_message_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessagesStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessagesStatus");
        }
    }
}
