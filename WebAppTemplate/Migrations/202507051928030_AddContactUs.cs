namespace PetBoardingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactUs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactUsModels",
                c => new
                    {
                        ContactID = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Message = c.String(),
                        DatePosted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContactID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactUsModels");
        }
    }
}
