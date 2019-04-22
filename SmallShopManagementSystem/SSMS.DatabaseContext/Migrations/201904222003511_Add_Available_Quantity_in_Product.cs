namespace SSMS.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Available_Quantity_in_Product : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "AvailableQuantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "AvailableQuantity");
        }
    }
}
