namespace USOM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingPaymnetGatewqay : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CCAvanuePaymentResponse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentResponse = c.String(),
                        OrderId = c.String(),
                        TrackingId = c.String(),
                        BankRefNumber = c.String(),
                        OrderStatus = c.String(),
                        FailureMessage = c.String(),
                        PaymentMode = c.String(),
                        CardName = c.String(),
                        StatusCode = c.String(),
                        StatusMessage = c.String(),
                        Currency = c.String(),
                        Amount = c.String(),
                        TransactionDate = c.String(),
                        BinCountry = c.String(),
                        Title = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        FilePath = c.String(),
                        CreationDate = c.DateTime(),
                        LastModificationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DonationEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Message = c.String(),
                        PinCode = c.String(),
                        Amount = c.Double(nullable: false),
                        Title = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        FilePath = c.String(),
                        CreationDate = c.DateTime(),
                        LastModificationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DonationEntities");
            DropTable("dbo.CCAvanuePaymentResponse");
        }
    }
}
