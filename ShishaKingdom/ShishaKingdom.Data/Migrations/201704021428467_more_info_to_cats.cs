namespace ShishaKingdom.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class more_info_to_cats : DbMigration
    {
        public override void Up()
        {
      
            AddColumn("dbo.Categories", "Description", c => c.String());
            AddColumn("dbo.Categories", "ImgUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "ImgUrl");
            DropColumn("dbo.Categories", "Description");
        }
    }
}
