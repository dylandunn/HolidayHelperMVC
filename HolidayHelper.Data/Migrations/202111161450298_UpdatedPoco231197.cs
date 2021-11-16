namespace HolidayHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPoco231197 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GiftReminder", "DaysLeftToBuyGift");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GiftReminder", "DaysLeftToBuyGift", c => c.DateTime(nullable: false));
        }
    }
}
