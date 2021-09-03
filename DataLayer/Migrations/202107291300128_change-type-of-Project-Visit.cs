namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetypeofProjectVisit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "ProjectVisit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "ProjectVisit", c => c.Boolean(nullable: false));
        }
    }
}
