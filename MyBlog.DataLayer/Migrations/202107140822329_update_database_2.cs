namespace MyBlog.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_database_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "ImageName", c => c.String(nullable: false));
            AddColumn("dbo.Posts", "ImageAlt", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Posts", "PostTitle", c => c.String(nullable: false, maxLength: 65));
            AlterColumn("dbo.Posts", "PostDescription", c => c.String(nullable: false, maxLength: 160));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "PostDescription", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Posts", "PostTitle", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Posts", "ImageAlt");
            DropColumn("dbo.Posts", "ImageName");
        }
    }
}
