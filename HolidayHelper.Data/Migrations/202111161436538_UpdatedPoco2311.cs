namespace HolidayHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPoco2311 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GiftReminder", "Occasion", c => c.String());
            AddColumn("dbo.GiftReminder", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.GiftReminder", "GiftNeededBy", c => c.DateTime(nullable: false));
            AddColumn("dbo.GiftReminder", "DaysLeftToBuyGift", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GiftReminder", "DaysLeftToBuyGift");
            DropColumn("dbo.GiftReminder", "GiftNeededBy");
            DropColumn("dbo.GiftReminder", "CreatedDate");
            DropColumn("dbo.GiftReminder", "Occasion");
        }
    }
}
