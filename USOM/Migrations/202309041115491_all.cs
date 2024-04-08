namespace USOM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class all : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnnouncementCategory",
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
            
            CreateTable(
                "dbo.Announcement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnnouncementCategoryId = c.Int(nullable: false),
                        Title = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        FilePath = c.String(),
                        CreationDate = c.DateTime(),
                        LastModificationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnnouncementCategory", t => t.AnnouncementCategoryId, cascadeDelete: true)
                .Index(t => t.AnnouncementCategoryId);
            
            CreateTable(
                "dbo.AnnualReport",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        FilePath = c.String(),
                        CreationDate = c.DateTime(),
                        LastModificationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BlogCategory",
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
            
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BlogCategoryId = c.Int(nullable: false),
                        Excerpt = c.String(),
                        PostedBy = c.String(),
                        Description = c.String(),
                        YoutubeLink = c.String(),
                        Tags = c.String(),
                        IsFeatured = c.Boolean(nullable: false),
                        Title = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        FilePath = c.String(),
                        CreationDate = c.DateTime(),
                        LastModificationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogCategory", t => t.BlogCategoryId, cascadeDelete: true)
                .Index(t => t.BlogCategoryId);
            
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Message = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Subject = c.String(),
                        Title = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        FilePath = c.String(),
                        CreationDate = c.DateTime(),
                        LastModificationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventTypeId = c.Int(nullable: false),
                        Excerpt = c.String(),
                        Description = c.String(),
                        YoutubeLink = c.String(),
                        Title = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        FilePath = c.String(),
                        CreationDate = c.DateTime(),
                        LastModificationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventType", t => t.EventTypeId, cascadeDelete: true)
                .Index(t => t.EventTypeId);
            
            CreateTable(
                "dbo.EventType",
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
            
            CreateTable(
                "dbo.Faq",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Title = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        FilePath = c.String(),
                        CreationDate = c.DateTime(),
                        LastModificationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Testimonial",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Designation = c.String(),
                        Title = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        FilePath = c.String(),
                        CreationDate = c.DateTime(),
                        LastModificationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gallery",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        FilePath = c.String(),
                        CreationDate = c.DateTime(),
                        LastModificationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GalleryVideo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YoutubeVideoLink = c.String(),
                        Title = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        FilePath = c.String(),
                        CreationDate = c.DateTime(),
                        LastModificationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.History",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.String(),
                        Description = c.String(),
                        Title = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        FilePath = c.String(),
                        CreationDate = c.DateTime(),
                        LastModificationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Price = c.String(),
                        Title = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        FilePath = c.String(),
                        CreationDate = c.DateTime(),
                        LastModificationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publication",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublicationTypeId = c.Int(nullable: false),
                        Title = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        FilePath = c.String(),
                        CreationDate = c.DateTime(),
                        LastModificationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PublicationType", t => t.PublicationTypeId, cascadeDelete: true)
                .Index(t => t.PublicationTypeId);
            
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ServiceCategory",
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
            
            CreateTable(
                "dbo.Service",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceCategoryId = c.Int(nullable: false),
                        Excerpt = c.String(),
                        Description = c.String(),
                        Price = c.String(),
                        IsFeatured = c.Boolean(nullable: false),
                        Title = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        FilePath = c.String(),
                        CreationDate = c.DateTime(),
                        LastModificationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceCategory", t => t.ServiceCategoryId, cascadeDelete: true)
                .Index(t => t.ServiceCategoryId);
            
            CreateTable(
                "dbo.Slider",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Captions = c.String(),
                        SubCaptions = c.String(),
                        Title = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        FilePath = c.String(),
                        CreationDate = c.DateTime(),
                        LastModificationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Supporter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Title = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        FilePath = c.String(),
                        CreationDate = c.DateTime(),
                        LastModificationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Service", "ServiceCategoryId", "dbo.ServiceCategory");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Publication", "PublicationTypeId", "dbo.PublicationType");
            DropForeignKey("dbo.Event", "EventTypeId", "dbo.EventType");
            DropForeignKey("dbo.Blog", "BlogCategoryId", "dbo.BlogCategory");
            DropForeignKey("dbo.Announcement", "AnnouncementCategoryId", "dbo.AnnouncementCategory");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Service", new[] { "ServiceCategoryId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Publication", new[] { "PublicationTypeId" });
            DropIndex("dbo.Event", new[] { "EventTypeId" });
            DropIndex("dbo.Blog", new[] { "BlogCategoryId" });
            DropIndex("dbo.Announcement", new[] { "AnnouncementCategoryId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Supporter");
            DropTable("dbo.Slider");
            DropTable("dbo.Service");
            DropTable("dbo.ServiceCategory");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PublicationType");
            DropTable("dbo.Publication");
            DropTable("dbo.Products");
            DropTable("dbo.History");
            DropTable("dbo.GalleryVideo");
            DropTable("dbo.Gallery");
            DropTable("dbo.Testimonial");
            DropTable("dbo.Faq");
            DropTable("dbo.EventType");
            DropTable("dbo.Event");
            DropTable("dbo.ContactUs");
            DropTable("dbo.Blog");
            DropTable("dbo.BlogCategory");
            DropTable("dbo.AnnualReport");
            DropTable("dbo.Announcement");
            DropTable("dbo.AnnouncementCategory");
        }
    }
}
