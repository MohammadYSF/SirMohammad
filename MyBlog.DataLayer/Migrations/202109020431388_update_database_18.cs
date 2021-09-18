namespace MyBlog.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_database_18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "isAuthor", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "isAuthor");
        }
    }
}
