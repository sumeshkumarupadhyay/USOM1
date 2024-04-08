namespace USOM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLinktoAnnualReporttable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnnualReport", "DocumentLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AnnualReport", "DocumentLink");
        }
    }
}
