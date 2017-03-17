namespace ShishaKingdom.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subcategoreis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "SubCategories_Id", c => c.Int());
            CreateIndex("dbo.Categories", "SubCategories_Id");
            AddForeignKey("dbo.Categories", "SubCategories_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "SubCategories_Id", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "SubCategories_Id" });
            DropColumn("dbo.Categories", "SubCategories_Id");
        }
    }
}
