namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbcreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogCats",
                c => new
                    {
                        CatId = c.Int(nullable: false, identity: true),
                        CatName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.CatId);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        BlogSubject = c.String(nullable: false, maxLength: 200),
                        CatId = c.Int(nullable: false),
                        BlogDesc = c.String(nullable: false, maxLength: 250),
                        BlogContent = c.String(nullable: false),
                        BlogImageName = c.String(nullable: false),
                        BlogTag = c.String(nullable: false, maxLength: 200),
                        BlogVisit = c.Boolean(nullable: false),
                        BlogDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BlogId)
                .ForeignKey("dbo.BlogCats", t => t.CatId, cascadeDelete: true)
                .Index(t => t.CatId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        PageId = c.Int(nullable: false),
                        BlogId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 200),
                        UserEmail = c.String(),
                        UserComment = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .ForeignKey("dbo.pages", t => t.PageId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.PageId)
                .Index(t => t.BlogId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.pages",
                c => new
                    {
                        PageID = c.Int(nullable: false, identity: true),
                        PageType = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.PageID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectSubject = c.String(nullable: false, maxLength: 200),
                        ServiceId = c.Int(nullable: false),
                        ProjectDesc = c.String(nullable: false, maxLength: 300),
                        ProjectContent = c.String(nullable: false),
                        ProjectVisit = c.Boolean(nullable: false),
                        ProjectImage = c.String(),
                        ProjectStartDate = c.DateTime(nullable: false),
                        ProjectEndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Comments", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Comments", "PageId", "dbo.pages");
            DropForeignKey("dbo.Comments", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "CatId", "dbo.BlogCats");
            DropIndex("dbo.Projects", new[] { "ServiceId" });
            DropIndex("dbo.Comments", new[] { "ProjectId" });
            DropIndex("dbo.Comments", new[] { "BlogId" });
            DropIndex("dbo.Comments", new[] { "PageId" });
            DropIndex("dbo.Blogs", new[] { "CatId" });
            DropTable("dbo.Services");
            DropTable("dbo.Projects");
            DropTable("dbo.pages");
            DropTable("dbo.Comments");
            DropTable("dbo.Blogs");
            DropTable("dbo.BlogCats");
        }
    }
}
