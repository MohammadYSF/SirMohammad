namespace MyBlog.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_database_17 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comments", name: "Comment_1_CommentID", newName: "Comment1_CommentID");
            RenameIndex(table: "dbo.Comments", name: "IX_Comment_1_CommentID", newName: "IX_Comment1_CommentID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Comments", name: "IX_Comment1_CommentID", newName: "IX_Comment_1_CommentID");
            RenameColumn(table: "dbo.Comments", name: "Comment1_CommentID", newName: "Comment_1_CommentID");
        }
    }
}
