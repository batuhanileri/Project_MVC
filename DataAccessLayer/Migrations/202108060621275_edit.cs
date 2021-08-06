namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterTelephones", c => c.String());
            AddColumn("dbo.Writers", "WriterAbout", c => c.String());
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WriterTelephones", c => c.Double(nullable: false));
            AddColumn("dbo.Writers", "WriterAbout", c => c.Double(nullable: false));
        }
    }
}
