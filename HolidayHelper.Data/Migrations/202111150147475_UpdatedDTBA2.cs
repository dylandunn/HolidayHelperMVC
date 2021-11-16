namespace HolidayHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDTBA2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GiftReminder", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.GiftReminder", "GiftNeededBy", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GiftReminder", "GiftNeededBy");
            DropColumn("dbo.GiftReminder", "CreatedDate");
        }
    }
}
