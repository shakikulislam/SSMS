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
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
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
                        SupplierId = c.Int(nullable: false),
                        ProductCode = c.String(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductCode = c.String(),
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
                        Product_Id = c.Int(),
                        Purchase_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Purchases", t => t.Purchase_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Purchase_Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                        ContactPerson = c.String(nullable: false),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                        LoyalityPoint = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SaleDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductName = c.String(),
                        AvailableQuantity = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        UnitPrice = c.Int(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                        SaleId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sales", t => t.SaleId, cascadeDelete: true)
                .Index(t => t.SaleId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Date = c.DateTime(nullable: false),
                        LoyalityPoint = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SaleVMs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        customer_Id = c.Int(),
                        sale_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.customer_Id)
                .ForeignKey("dbo.Sales", t => t.sale_Id)
                .Index(t => t.customer_Id)
                .Index(t => t.sale_Id);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.product_Id)
                .Index(t => t.product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stocks", "product_Id", "dbo.Products");
            DropForeignKey("dbo.SaleVMs", "sale_Id", "dbo.Sales");
            DropForeignKey("dbo.SaleVMs", "customer_Id", "dbo.Customers");
            DropForeignKey("dbo.SaleDetails", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseDetails", "Purchase_Id", "dbo.Purchases");
            DropForeignKey("dbo.PurchaseDetails", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Purchases", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Stocks", new[] { "product_Id" });
            DropIndex("dbo.SaleVMs", new[] { "sale_Id" });
            DropIndex("dbo.SaleVMs", new[] { "customer_Id" });
            DropIndex("dbo.SaleDetails", new[] { "SaleId" });
            DropIndex("dbo.PurchaseDetails", new[] { "Purchase_Id" });
            DropIndex("dbo.PurchaseDetails", new[] { "Product_Id" });
            DropIndex("dbo.Purchases", new[] { "Product_Id" });
            DropIndex("dbo.Purchases", new[] { "SupplierId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Stocks");
            DropTable("dbo.SaleVMs");
            DropTable("dbo.Sales");
            DropTable("dbo.SaleDetails");
            DropTable("dbo.Customers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.PurchaseDetails");
            DropTable("dbo.Purchases");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
