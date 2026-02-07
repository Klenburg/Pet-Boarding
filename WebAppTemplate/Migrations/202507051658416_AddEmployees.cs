namespace PetBoardingApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployees : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeModels", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.EmployeeModels", "LastName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeModels", "LastName", c => c.String());
            AlterColumn("dbo.EmployeeModels", "FirstName", c => c.String());
        }
    }
}
