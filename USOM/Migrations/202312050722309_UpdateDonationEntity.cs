namespace USOM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDonationEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonationEntities", "BankReferenceId", c => c.String());
            AddColumn("dbo.DonationEntities", "TransactionId", c => c.String());
            AddColumn("dbo.DonationEntities", "OrderStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonationEntities", "OrderStatus");
            DropColumn("dbo.DonationEntities", "TransactionId");
            DropColumn("dbo.DonationEntities", "BankReferenceId");
        }
    }
}
