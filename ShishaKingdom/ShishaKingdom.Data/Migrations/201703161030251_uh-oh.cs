namespace ShishaKingdom.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uhoh : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.WishLists", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WishLists", "UserId", c => c.String());
        }
    }
}
