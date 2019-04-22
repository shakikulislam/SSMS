namespace SSMS.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Produduct_DropDown : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Purchases", "Product_Id", "dbo.Products");
            DropIndex("dbo.Purchases", new[] { "Product_Id" });
            RenameColumn(table: "dbo.Purchases", name: "Product_Id", newName: "ProductId");
            AddColumn("dbo.PurchaseDetails", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.Purchases", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Purchases", "ProductId");
            CreateIndex("dbo.PurchaseDetails", "ProductId");
            AddForeignKey("dbo.PurchaseDetails", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Purchases", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            DropColumn("dbo.PurchaseDetails", "Product");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseDetails", "Product", c => c.String());
            DropForeignKey("dbo.Purchases", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PurchaseDetails", "ProductId", "dbo.Products");
            DropIndex("dbo.PurchaseDetails", new[] { "ProductId" });
            DropIndex("dbo.Purchases", new[] { "ProductId" });
            AlterColumn("dbo.Purchases", "ProductId", c => c.Int());
            DropColumn("dbo.PurchaseDetails", "ProductId");
            RenameColumn(table: "dbo.Purchases", name: "ProductId", newName: "Product_Id");
            CreateIndex("dbo.Purchases", "Product_Id");
            AddForeignKey("dbo.Purchases", "Product_Id", "dbo.Products", "Id");
        }
    }
}
