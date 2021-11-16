namespace HolidayHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDTBug : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GiftReminder", "CreatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GiftReminder", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
