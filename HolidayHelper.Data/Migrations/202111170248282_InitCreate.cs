namespace HolidayHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GiftIdea",
                c => new
                    {
                        GiftIdeaId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Product = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Location = c.String(),
                        WebsiteLink = c.String(),
                    })
                .PrimaryKey(t => t.GiftIdeaId);
            
            CreateTable(
                "dbo.GiftReminder",
                c => new
                    {
                        GiftReminderId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        RecipientId = c.Int(nullable: false),
                        Occasion = c.String(),
                        CreatedDate = c.DateTime(),
                        GiftNeededBy = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GiftReminderId)
                .ForeignKey("dbo.Recipient", t => t.RecipientId, cascadeDelete: true)
                .Index(t => t.RecipientId);
            
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
            
            CreateTable(
                "dbo.GiftReminderGiftIdea",
                c => new
                    {
                        GiftReminder_GiftReminderId = c.Int(nullable: false),
                        GiftIdea_GiftIdeaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GiftReminder_GiftReminderId, t.GiftIdea_GiftIdeaId })
                .ForeignKey("dbo.GiftReminder", t => t.GiftReminder_GiftReminderId, cascadeDelete: true)
                .ForeignKey("dbo.GiftIdea", t => t.GiftIdea_GiftIdeaId, cascadeDelete: true)
                .Index(t => t.GiftReminder_GiftReminderId)
                .Index(t => t.GiftIdea_GiftIdeaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.GiftReminder", "RecipientId", "dbo.Recipient");
            DropForeignKey("dbo.GiftReminderGiftIdea", "GiftIdea_GiftIdeaId", "dbo.GiftIdea");
            DropForeignKey("dbo.GiftReminderGiftIdea", "GiftReminder_GiftReminderId", "dbo.GiftReminder");
            DropIndex("dbo.GiftReminderGiftIdea", new[] { "GiftIdea_GiftIdeaId" });
            DropIndex("dbo.GiftReminderGiftIdea", new[] { "GiftReminder_GiftReminderId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.GiftReminder", new[] { "RecipientId" });
            DropTable("dbo.GiftReminderGiftIdea");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Recipient");
            DropTable("dbo.GiftReminder");
            DropTable("dbo.GiftIdea");
        }
    }
}
