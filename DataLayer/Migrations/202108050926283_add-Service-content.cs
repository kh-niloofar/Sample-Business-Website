namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addServicecontent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "ServiceContent", c => c.String(nullable: false, maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "ServiceContent");
        }
    }
}
