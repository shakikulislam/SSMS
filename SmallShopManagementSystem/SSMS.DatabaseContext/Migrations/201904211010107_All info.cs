namespace SSMS.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Allinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseDetails", "PurchaseId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseDetails", "PurchaseId");
        }
    }
}
