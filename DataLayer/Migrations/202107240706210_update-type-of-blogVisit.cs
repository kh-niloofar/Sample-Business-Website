namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetypeofblogVisit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "BlogVisit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "BlogVisit", c => c.Boolean(nullable: false));
        }
    }
}
