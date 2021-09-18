namespace MyBlog.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_database_15 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "PostKeywords", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "PostKeywords", c => c.String(nullable: false));
        }
    }
}
