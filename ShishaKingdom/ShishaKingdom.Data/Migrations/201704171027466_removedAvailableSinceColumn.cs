namespace ShishaKingdom.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedAvailableSinceColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "AvailableSince");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "AvailableSince", c => c.DateTime());
        }
    }
}
