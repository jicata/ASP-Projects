namespace ShishaKingdom.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wishlist_checkout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WishLists", "IsCheckedOut", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WishLists", "IsCheckedOut");
        }
    }
}
