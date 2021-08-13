namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SignUps",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        E_Mail = c.String(),
                        Password = c.String(),
                        RePassword = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SignUps");
        }
    }
}
