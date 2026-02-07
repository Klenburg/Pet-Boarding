namespace PetBoardingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookingCRUD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingModels", "Cost", c => c.Double(nullable: false));
            AlterColumn("dbo.BookingModels", "StartTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.BookingModels", "EndTime", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.BookingModels", "BookingCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingModels", "BookingCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BookingModels", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BookingModels", "StartTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.BookingModels", "Cost");
        }
    }
}
