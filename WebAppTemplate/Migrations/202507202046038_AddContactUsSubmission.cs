namespace PetBoardingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactUsSubmission : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactUsSubmissions",
                c => new
                    {
                        ContactUsSubmissionID = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ContactUsSubmissionID);
            
            DropTable("dbo.ContactUsModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ContactUsModels",
                c => new
                    {
                        ContactID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(maxLength: 100),
                        Message = c.String(nullable: false, maxLength: 1000),
                        DatePosted = c.DateTime(nullable: false),
                        DateTimeCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContactID);
            
            DropTable("dbo.ContactUsSubmissions");
        }
    }
}
