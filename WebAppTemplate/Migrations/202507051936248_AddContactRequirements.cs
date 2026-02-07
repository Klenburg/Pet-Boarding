namespace PetBoardingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactRequirements : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContactUsModels", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ContactUsModels", "Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.ContactUsModels", "Message", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContactUsModels", "Message", c => c.String());
            AlterColumn("dbo.ContactUsModels", "Email", c => c.String());
            AlterColumn("dbo.ContactUsModels", "Name", c => c.String());
        }
    }
}
