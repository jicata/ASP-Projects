namespace SpaBackend.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phone_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Phones", "InStock", c => c.Boolean(nullable: false));
            AddColumn("dbo.Phones", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Phones", "ImageUrl");
            DropColumn("dbo.Phones", "InStock");
        }
    }
}
