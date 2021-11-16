namespace HolidayHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDTBA25 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GiftReminder", "CreatedDate");
            DropColumn("dbo.GiftReminder", "GiftNeededBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GiftReminder", "GiftNeededBy", c => c.DateTime(nullable: false));
            AddColumn("dbo.GiftReminder", "CreatedDate", c => c.DateTime());
        }
    }
}
