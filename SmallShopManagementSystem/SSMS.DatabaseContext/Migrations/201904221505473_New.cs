namespace SSMS.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Purchases", "ProductId", "dbo.Products");
            DropIndex("dbo.Purchases", new[] { "ProductId" });
            RenameColumn(table: "dbo.Purchases", name: "ProductId", newName: "Product_Id");
            AlterColumn("dbo.Purchases", "Product_Id", c => c.Int());
            CreateIndex("dbo.Purchases", "Product_Id");
            AddForeignKey("dbo.Purchases", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "Product_Id", "dbo.Products");
            DropIndex("dbo.Purchases", new[] { "Product_Id" });
            AlterColumn("dbo.Purchases", "Product_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Purchases", name: "Product_Id", newName: "ProductId");
            CreateIndex("dbo.Purchases", "ProductId");
            AddForeignKey("dbo.Purchases", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
