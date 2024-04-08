namespace USOM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addlinktopublication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Publication", "DocumentLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Publication", "DocumentLink");
        }
    }
}
