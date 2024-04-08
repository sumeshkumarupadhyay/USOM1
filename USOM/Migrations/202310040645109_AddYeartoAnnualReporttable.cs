namespace USOM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddYeartoAnnualReporttable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnnualReport", "YearofDocument", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AnnualReport", "YearofDocument");
        }
    }
}
