namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class image_not_required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "BlogImageName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "BlogImageName", c => c.String(nullable: false));
        }
    }
}
