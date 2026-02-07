namespace PetBoardingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PetModels",
                c => new
                    {
                        PetID = c.Guid(nullable: false),
                        PetName = c.String(nullable: false, maxLength: 100),
                        Breed = c.String(maxLength: 100),
                        PetAge = c.Int(nullable: false),
                        FeedInstruct = c.String(nullable: false, maxLength: 1000),
                        SpecialInstruct = c.String(maxLength: 1000),
                        EmergencyContact = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PetID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PetModels");
        }
    }
}
