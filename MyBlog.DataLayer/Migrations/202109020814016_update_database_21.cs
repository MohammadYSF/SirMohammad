namespace MyBlog.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_database_21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "UserID", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "UserID" });
            DropColumn("dbo.Posts", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "UserID");
            AddForeignKey("dbo.Posts", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}
