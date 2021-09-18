namespace MyBlog.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_database_27 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WebsiteDetails", "WebsitePersianName", c => c.String(nullable: false));
            AddColumn("dbo.WebsiteDetails", "WebsiteEnglishName", c => c.String(nullable: false));
            DropColumn("dbo.WebsiteDetails", "WebsiteName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WebsiteDetails", "WebsiteName", c => c.String(nullable: false));
            DropColumn("dbo.WebsiteDetails", "WebsiteEnglishName");
            DropColumn("dbo.WebsiteDetails", "WebsitePersianName");
        }
    }
}
