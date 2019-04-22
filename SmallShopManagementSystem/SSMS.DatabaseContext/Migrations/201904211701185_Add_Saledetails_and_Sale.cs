namespace SSMS.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Saledetails_and_Sale : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleDetails", "SaleId", "dbo.Sales");
            DropIndex("dbo.SaleDetails", new[] { "SaleId" });
            DropTable("dbo.Sales");
            DropTable("dbo.SaleDetails");
        }
    }
}
