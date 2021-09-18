namespace MyBlog.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_database_8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ImageName", c => c.String(maxLength: 300));
            AddColumn("dbo.Users", "ShortDescription", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ShortDescription");
            DropColumn("dbo.Users", "ImageName");
        }
    }
}
