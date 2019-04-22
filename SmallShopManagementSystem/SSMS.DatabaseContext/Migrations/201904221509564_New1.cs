namespace SSMS.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "ProductCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "ProductCode");
        }
    }
}
