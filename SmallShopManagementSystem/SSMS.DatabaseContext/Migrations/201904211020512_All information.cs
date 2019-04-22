namespace SSMS.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Allinformation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseDetails", "Purchase_Id", "dbo.Purchases");
            DropForeignKey("dbo.PurchaseDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PurchaseDetails", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.PurchaseDetails", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseDetails", new[] { "ProductId" });
            DropIndex("dbo.PurchaseDetails", new[] { "Purchase_Id" });
            DropColumn("dbo.PurchaseDetails", "PurchaseId");
            RenameColumn(table: "dbo.PurchaseDetails", name: "Purchase_Id", newName: "PurchaseId");
            RenameColumn(table: "dbo.PurchaseDetails", name: "ProductId", newName: "Product_Id");
            RenameColumn(table: "dbo.PurchaseDetails", name: "SupplierId", newName: "Supplier_Id");
            AlterColumn("dbo.Purchases", "Bill", c => c.String());
            AlterColumn("dbo.PurchaseDetails", "Supplier_Id", c => c.Int());
            AlterColumn("dbo.PurchaseDetails", "Product_Id", c => c.Int());
            AlterColumn("dbo.PurchaseDetails", "PurchaseId", c => c.Int(nullable: false));
            AlterColumn("dbo.PurchaseDetails", "PurchaseId", c => c.Int(nullable: false));
            CreateIndex("dbo.PurchaseDetails", "PurchaseId");
            CreateIndex("dbo.PurchaseDetails", "Product_Id");
            CreateIndex("dbo.PurchaseDetails", "Supplier_Id");
            AddForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchases", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PurchaseDetails", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.PurchaseDetails", "Supplier_Id", "dbo.Suppliers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseDetails", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseDetails", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchases");
            DropIndex("dbo.PurchaseDetails", new[] { "Supplier_Id" });
            DropIndex("dbo.PurchaseDetails", new[] { "Product_Id" });
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseId" });
            AlterColumn("dbo.PurchaseDetails", "PurchaseId", c => c.Int());
            AlterColumn("dbo.PurchaseDetails", "PurchaseId", c => c.Long(nullable: false));
            AlterColumn("dbo.PurchaseDetails", "Product_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.PurchaseDetails", "Supplier_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Purchases", "Bill", c => c.String(nullable: false));
            RenameColumn(table: "dbo.PurchaseDetails", name: "Supplier_Id", newName: "SupplierId");
            RenameColumn(table: "dbo.PurchaseDetails", name: "Product_Id", newName: "ProductId");
            RenameColumn(table: "dbo.PurchaseDetails", name: "PurchaseId", newName: "Purchase_Id");
            AddColumn("dbo.PurchaseDetails", "PurchaseId", c => c.Long(nullable: false));
            CreateIndex("dbo.PurchaseDetails", "Purchase_Id");
            CreateIndex("dbo.PurchaseDetails", "ProductId");
            CreateIndex("dbo.PurchaseDetails", "SupplierId");
            AddForeignKey("dbo.PurchaseDetails", "SupplierId", "dbo.Suppliers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PurchaseDetails", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PurchaseDetails", "Purchase_Id", "dbo.Purchases", "Id");
        }
    }
}
