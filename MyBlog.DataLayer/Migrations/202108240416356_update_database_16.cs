namespace MyBlog.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_database_16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "ParentID", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "Comment_1_CommentID", c => c.Int());
            CreateIndex("dbo.Comments", "Comment_1_CommentID");
            AddForeignKey("dbo.Comments", "Comment_1_CommentID", "dbo.Comments", "CommentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Comment_1_CommentID", "dbo.Comments");
            DropIndex("dbo.Comments", new[] { "Comment_1_CommentID" });
            DropColumn("dbo.Comments", "Comment_1_CommentID");
            DropColumn("dbo.Comments", "ParentID");
        }
    }
}
