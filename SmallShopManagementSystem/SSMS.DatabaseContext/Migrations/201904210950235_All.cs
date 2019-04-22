namespace SSMS.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                        ReorderLevel = c.Int(nullable: false),
                        Description = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Bill = c.String(nullable: false),
                        Supplier_Id = c.Int(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Supplier_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplierId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Code = c.String(),
                        ManufacturedDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        PreviousCostPrice = c.Double(nullable: false),
                        PreviousMrp = c.Double(nullable: false),
                        NewCostPrice = c.Double(nullable: false),
                        NewMrp = c.Double(nullable: false),
                        Purchase_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.Purchase_Id)
                .Index(t => t.SupplierId)
                .Index(t => t.ProductId)
                .Index(t => t.Purchase_Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Contact = c.String(),
                        ContactPerson = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Contact = c.String(),
                        LoyalityPoint = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.PurchaseDetails", "Purchase_Id", "dbo.Purchases");
            DropForeignKey("dbo.PurchaseDetails", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Purchases", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.PurchaseDetails", new[] { "Purchase_Id" });
            DropIndex("dbo.PurchaseDetails", new[] { "ProductId" });
            DropIndex("dbo.PurchaseDetails", new[] { "SupplierId" });
            DropIndex("dbo.Purchases", new[] { "Product_Id" });
            DropIndex("dbo.Purchases", new[] { "Supplier_Id" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Customers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.PurchaseDetails");
            DropTable("dbo.Purchases");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
