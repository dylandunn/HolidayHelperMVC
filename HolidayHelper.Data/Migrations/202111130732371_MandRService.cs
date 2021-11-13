namespace HolidayHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MandRService : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GiftIdea",
                c => new
                    {
                        GiftIdeaId = c.Int(nullable: false, identity: true),
                        RecipientId = c.Int(nullable: false),
                        Product = c.String(),
                        Price = c.Double(nullable: false),
                        Location = c.String(),
                        WebsiteLink = c.String(),
                        GiftReminder_GiftReminderId = c.Int(),
                    })
                .PrimaryKey(t => t.GiftIdeaId)
                .ForeignKey("dbo.Recipient", t => t.RecipientId, cascadeDelete: true)
                .ForeignKey("dbo.GiftReminder", t => t.GiftReminder_GiftReminderId)
                .Index(t => t.RecipientId)
                .Index(t => t.GiftReminder_GiftReminderId);
            
            CreateTable(
                "dbo.Recipient",
                c => new
                    {
                        RecipientId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Relation = c.String(),
                        Interests = c.String(),
                        Avoid = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecipientId);
            
            CreateTable(
                "dbo.GiftReminder",
                c => new
                    {
                        GiftReminderId = c.Int(nullable: false, identity: true),
                        RecipientId = c.Int(nullable: false),
                        Occasion = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        GiftNeededBy = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GiftReminderId)
                .ForeignKey("dbo.Recipient", t => t.RecipientId, cascadeDelete: true)
                .Index(t => t.RecipientId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.GiftReminder", "RecipientId", "dbo.Recipient");
            DropForeignKey("dbo.GiftIdea", "GiftReminder_GiftReminderId", "dbo.GiftReminder");
            DropForeignKey("dbo.GiftIdea", "RecipientId", "dbo.Recipient");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.GiftReminder", new[] { "RecipientId" });
            DropIndex("dbo.GiftIdea", new[] { "GiftReminder_GiftReminderId" });
            DropIndex("dbo.GiftIdea", new[] { "RecipientId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.GiftReminder");
            DropTable("dbo.Recipient");
            DropTable("dbo.GiftIdea");
        }
    }
}
