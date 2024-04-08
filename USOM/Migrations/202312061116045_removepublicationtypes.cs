namespace USOM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removepublicationtypes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Publication", "PublicationTypeId", "dbo.PublicationType");
            DropIndex("dbo.Publication", new[] { "PublicationTypeId" });
            DropColumn("dbo.Publication", "PublicationTypeId");
            DropTable("dbo.PublicationType");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PublicationType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddOnMenu = c.Boolean(nullable: false),
                        Title = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        FilePath = c.String(),
                        CreationDate = c.DateTime(),
                        LastModificationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Publication", "PublicationTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Publication", "PublicationTypeId");
            AddForeignKey("dbo.Publication", "PublicationTypeId", "dbo.PublicationType", "Id", cascadeDelete: true);
        }
    }
}
