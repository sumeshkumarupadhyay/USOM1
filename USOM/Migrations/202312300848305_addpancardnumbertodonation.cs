namespace USOM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpancardnumbertodonation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donation", "PanNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Donation", "PanNumber");
        }
    }
}
