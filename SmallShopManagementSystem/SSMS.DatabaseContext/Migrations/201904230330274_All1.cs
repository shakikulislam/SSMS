namespace SSMS.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Code", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Code", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
