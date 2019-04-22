namespace SSMS.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SellVm : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleVMs", "sale_Id", "dbo.Sales");
            DropForeignKey("dbo.SaleVMs", "customer_Id", "dbo.Customers");
            DropIndex("dbo.SaleVMs", new[] { "sale_Id" });
            DropIndex("dbo.SaleVMs", new[] { "customer_Id" });
            DropTable("dbo.SaleVMs");
        }
    }
}
