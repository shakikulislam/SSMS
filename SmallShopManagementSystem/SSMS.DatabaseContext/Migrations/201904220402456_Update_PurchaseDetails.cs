namespace SSMS.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_PurchaseDetails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Purchases", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Purchases", new[] { "SupplierId" });
            DropIndex("dbo.Purchases", new[] { "ProductId" });
            RenameColumn(table: "dbo.Purchases", name: "ProductId", newName: "Product_Id");
            RenameColumn(table: "dbo.Purchases", name: "SupplierId", newName: "Supplier_Id");
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
            
            AlterColumn("dbo.Purchases", "Bill", c => c.String());
            AlterColumn("dbo.Purchases", "Supplier_Id", c => c.Int());
            AlterColumn("dbo.Purchases", "Product_Id", c => c.Int());
            CreateIndex("dbo.Purchases", "Supplier_Id");
            CreateIndex("dbo.Purchases", "Product_Id");
            AddForeignKey("dbo.Purchases", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Purchases", "Supplier_Id", "dbo.Suppliers", "Id");
            DropColumn("dbo.Purchases", "Code");
            DropColumn("dbo.Purchases", "ManufacturedDate");
            DropColumn("dbo.Purchases", "ExpireDate");
            DropColumn("dbo.Purchases", "Quantity");
            DropColumn("dbo.Purchases", "UnitPrice");
            DropColumn("dbo.Purchases", "TotalPrice");
            DropColumn("dbo.Purchases", "PreviousCostPrice");
            DropColumn("dbo.Purchases", "PreviousMrp");
            DropColumn("dbo.Purchases", "NewCostPrice");
            DropColumn("dbo.Purchases", "NewMrp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchases", "NewMrp", c => c.Double(nullable: false));
            AddColumn("dbo.Purchases", "NewCostPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Purchases", "PreviousMrp", c => c.Double(nullable: false));
            AddColumn("dbo.Purchases", "PreviousCostPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Purchases", "TotalPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Purchases", "UnitPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Purchases", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Purchases", "ExpireDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Purchases", "ManufacturedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Purchases", "Code", c => c.String());
            DropForeignKey("dbo.Purchases", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.Purchases", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.PurchaseDetails", "Purchase_Id", "dbo.Purchases");
            DropForeignKey("dbo.PurchaseDetails", "Product_Id", "dbo.Products");
            DropIndex("dbo.PurchaseDetails", new[] { "Purchase_Id" });
            DropIndex("dbo.PurchaseDetails", new[] { "Product_Id" });
            DropIndex("dbo.Purchases", new[] { "Product_Id" });
            DropIndex("dbo.Purchases", new[] { "Supplier_Id" });
            AlterColumn("dbo.Purchases", "Product_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Purchases", "Supplier_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Purchases", "Bill", c => c.String(nullable: false));
            DropTable("dbo.PurchaseDetails");
            RenameColumn(table: "dbo.Purchases", name: "Supplier_Id", newName: "SupplierId");
            RenameColumn(table: "dbo.Purchases", name: "Product_Id", newName: "ProductId");
            CreateIndex("dbo.Purchases", "ProductId");
            CreateIndex("dbo.Purchases", "SupplierId");
            AddForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Purchases", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
