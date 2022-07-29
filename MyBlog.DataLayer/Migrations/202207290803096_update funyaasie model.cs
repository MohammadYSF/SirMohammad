namespace MyBlog.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatefunyaasiemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FunYaasies", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.FunYaasies", "ModificationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FunYaasies", "ModificationDate");
            DropColumn("dbo.FunYaasies", "CreationDate");
        }
    }
}
