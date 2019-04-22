namespace SSMS.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseDetails", "ProductId", "dbo.Products");
            DropIndex("dbo.PurchaseDetails", new[] { "ProductId" });
            RenameColumn(table: "dbo.PurchaseDetails", name: "ProductId", newName: "Product_Id");
            AddColumn("dbo.PurchaseDetails", "ProductCode", c => c.String());
            AlterColumn("dbo.PurchaseDetails", "Product_Id", c => c.Int());
            CreateIndex("dbo.PurchaseDetails", "Product_Id");
            AddForeignKey("dbo.PurchaseDetails", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseDetails", "Product_Id", "dbo.Products");
            DropIndex("dbo.PurchaseDetails", new[] { "Product_Id" });
            AlterColumn("dbo.PurchaseDetails", "Product_Id", c => c.Int(nullable: false));
            DropColumn("dbo.PurchaseDetails", "ProductCode");
            RenameColumn(table: "dbo.PurchaseDetails", name: "Product_Id", newName: "ProductId");
            CreateIndex("dbo.PurchaseDetails", "ProductId");
            AddForeignKey("dbo.PurchaseDetails", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
