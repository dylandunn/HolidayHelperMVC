namespace HolidayHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedGIPOCOs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GiftIdea", "RecipientId", "dbo.Recipient");
            DropIndex("dbo.GiftIdea", new[] { "RecipientId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.GiftIdea", "RecipientId");
            AddForeignKey("dbo.GiftIdea", "RecipientId", "dbo.Recipient", "RecipientId", cascadeDelete: true);
        }
    }
}
