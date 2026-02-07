namespace PetBoardingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContact : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.BookingModels", "OwnerID");
            AddForeignKey("dbo.BookingModels", "OwnerID", "dbo.OwnerModels", "OwnerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingModels", "OwnerID", "dbo.OwnerModels");
            DropIndex("dbo.BookingModels", new[] { "OwnerID" });
        }
    }
}
