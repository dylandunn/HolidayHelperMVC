namespace HolidayHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FluentAPI : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GiftIdea", "GiftReminder_GiftReminderId", "dbo.GiftReminder");
            DropIndex("dbo.GiftIdea", new[] { "GiftReminder_GiftReminderId" });
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
            
            DropColumn("dbo.GiftIdea", "GiftReminder_GiftReminderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GiftIdea", "GiftReminder_GiftReminderId", c => c.Int());
            DropForeignKey("dbo.GiftReminderGiftIdea", "GiftIdea_GiftIdeaId", "dbo.GiftIdea");
            DropForeignKey("dbo.GiftReminderGiftIdea", "GiftReminder_GiftReminderId", "dbo.GiftReminder");
            DropIndex("dbo.GiftReminderGiftIdea", new[] { "GiftIdea_GiftIdeaId" });
            DropIndex("dbo.GiftReminderGiftIdea", new[] { "GiftReminder_GiftReminderId" });
            DropTable("dbo.GiftReminderGiftIdea");
            CreateIndex("dbo.GiftIdea", "GiftReminder_GiftReminderId");
            AddForeignKey("dbo.GiftIdea", "GiftReminder_GiftReminderId", "dbo.GiftReminder", "GiftReminderId");
        }
    }
}
