namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableblogIdandprojectIdincomments : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Comments", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Comments", new[] { "BlogId" });
            DropIndex("dbo.Comments", new[] { "ProjectId" });
            AlterColumn("dbo.Comments", "BlogId", c => c.Int());
            AlterColumn("dbo.Comments", "ProjectId", c => c.Int());
            CreateIndex("dbo.Comments", "BlogId");
            CreateIndex("dbo.Comments", "ProjectId");
            AddForeignKey("dbo.Comments", "BlogId", "dbo.Blogs", "BlogId");
            AddForeignKey("dbo.Comments", "ProjectId", "dbo.Projects", "ProjectId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Comments", "BlogId", "dbo.Blogs");
            DropIndex("dbo.Comments", new[] { "ProjectId" });
            DropIndex("dbo.Comments", new[] { "BlogId" });
            AlterColumn("dbo.Comments", "ProjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "BlogId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "ProjectId");
            CreateIndex("dbo.Comments", "BlogId");
            AddForeignKey("dbo.Comments", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "BlogId", "dbo.Blogs", "BlogId", cascadeDelete: true);
        }
    }
}
