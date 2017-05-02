namespace ShishaKingdom.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_orders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MadeOn = c.DateTime(),
                        Status = c.Int(nullable: false),
                        Customer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            AddColumn("dbo.Products", "Order_Id", c => c.Int());
            CreateIndex("dbo.Products", "Order_Id");
            AddForeignKey("dbo.Products", "Order_Id", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropColumn("dbo.Products", "Order_Id");
            DropTable("dbo.Orders");
        }
    }
}
