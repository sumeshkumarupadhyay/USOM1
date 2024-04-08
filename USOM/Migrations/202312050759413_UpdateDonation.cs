namespace USOM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDonation : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DonationEntities", newName: "Donation");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Donation", newName: "DonationEntities");
        }
    }
}
