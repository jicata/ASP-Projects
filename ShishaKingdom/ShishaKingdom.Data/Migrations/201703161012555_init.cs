namespace ShishaKingdom.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvailableSince = c.DateTime(),
                        Availability = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        Category_Id = c.Int(),
                        WishList_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.WishLists", t => t.WishList_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.WishList_Id);
            
            CreateTable(
                "dbo.WishLists",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "WishList_Id", "dbo.WishLists");
            DropForeignKey("dbo.WishLists", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.WishLists", new[] { "Id" });
            DropIndex("dbo.Products", new[] { "WishList_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropTable("dbo.WishLists");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
