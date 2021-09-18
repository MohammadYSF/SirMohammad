namespace MyBlog.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_database_14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostSubImages",
                c => new
                    {
                        SubID = c.Int(nullable: false, identity: true),
                        PostID = c.Int(nullable: false),
                        SubImageName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SubID)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostSubImages", "PostID", "dbo.Posts");
            DropIndex("dbo.PostSubImages", new[] { "PostID" });
            DropTable("dbo.PostSubImages");
        }
    }
}
