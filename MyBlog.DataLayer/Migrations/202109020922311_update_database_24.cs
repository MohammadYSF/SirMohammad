namespace MyBlog.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_database_24 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "PostAuthor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "PostAuthor", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
