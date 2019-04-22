namespace SSMS.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stock_Model : DbMigration
    {
        public override void Up()
        {
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
            DropIndex("dbo.Stocks", new[] { "product_Id" });
            DropTable("dbo.Stocks");
        }
    }
}
