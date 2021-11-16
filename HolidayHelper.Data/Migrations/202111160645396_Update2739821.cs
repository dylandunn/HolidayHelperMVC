namespace HolidayHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2739821 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GiftReminder", "Occasion");
            DropColumn("dbo.GiftReminder", "CreatedDate");
            DropColumn("dbo.GiftReminder", "GiftNeededBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GiftReminder", "GiftNeededBy", c => c.DateTime(nullable: false));
            AddColumn("dbo.GiftReminder", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.GiftReminder", "Occasion", c => c.String());
        }
    }
}
