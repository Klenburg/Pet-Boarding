namespace PetBoardingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixValidation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookingModels", "PetID", "dbo.PetModels");
            DropIndex("dbo.BookingModels", new[] { "PetID" });
            AlterColumn("dbo.BookingModels", "PetID", c => c.Guid());
            CreateIndex("dbo.BookingModels", "PetID");
            AddForeignKey("dbo.BookingModels", "PetID", "dbo.PetModels", "PetID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingModels", "PetID", "dbo.PetModels");
            DropIndex("dbo.BookingModels", new[] { "PetID" });
            AlterColumn("dbo.BookingModels", "PetID", c => c.Guid(nullable: false));
            CreateIndex("dbo.BookingModels", "PetID");
            AddForeignKey("dbo.BookingModels", "PetID", "dbo.PetModels", "PetID", cascadeDelete: true);
        }
    }
}
