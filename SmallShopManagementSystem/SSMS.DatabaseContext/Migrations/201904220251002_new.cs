namespace SSMS.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseDetails", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchases");
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseId" });
            DropIndex("dbo.PurchaseDetails", new[] { "Supplier_Id" });
            RenameColumn(table: "dbo.PurchaseDetails", name: "PurchaseId", newName: "Purchase_Id");
            AlterColumn("dbo.PurchaseDetails", "Purchase_Id", c => c.Int());
            CreateIndex("dbo.PurchaseDetails", "Purchase_Id");
            AddForeignKey("dbo.PurchaseDetails", "Purchase_Id", "dbo.Purchases", "Id");
            DropColumn("dbo.PurchaseDetails", "Supplier_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseDetails", "Supplier_Id", c => c.Int());
            DropForeignKey("dbo.PurchaseDetails", "Purchase_Id", "dbo.Purchases");
            DropIndex("dbo.PurchaseDetails", new[] { "Purchase_Id" });
            AlterColumn("dbo.PurchaseDetails", "Purchase_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.PurchaseDetails", name: "Purchase_Id", newName: "PurchaseId");
            CreateIndex("dbo.PurchaseDetails", "Supplier_Id");
            CreateIndex("dbo.PurchaseDetails", "PurchaseId");
            AddForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchases", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PurchaseDetails", "Supplier_Id", "dbo.Suppliers", "Id");
        }
    }
}
