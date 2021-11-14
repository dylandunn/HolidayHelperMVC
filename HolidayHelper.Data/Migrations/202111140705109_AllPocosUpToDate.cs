namespace HolidayHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllPocosUpToDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GiftIdea", "OwnerId", c => c.Guid(nullable: false));
            AlterColumn("dbo.GiftIdea", "Product", c => c.String(nullable: false));
            DropColumn("dbo.GiftIdea", "RecipientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GiftIdea", "RecipientId", c => c.Int(nullable: false));
            AlterColumn("dbo.GiftIdea", "Product", c => c.String());
            DropColumn("dbo.GiftIdea", "OwnerId");
        }
    }
}
