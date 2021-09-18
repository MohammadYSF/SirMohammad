namespace MyBlog.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_database_26 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WebsiteDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WebsiteName = c.String(nullable: false),
                        WebsiteOwner = c.String(nullable: false),
                        AboutText = c.String(nullable: false),
                        ContactText = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        TelegramID = c.String(),
                        InstagramID = c.String(),
                        Email = c.String(),
                        LandingText = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WebsiteDetails");
        }
    }
}
