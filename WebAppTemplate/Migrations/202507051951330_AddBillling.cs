namespace PetBoardingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBilling : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillingModels",
                c => new
                    {
                        BillingID = c.Guid(nullable: false),
                        Tax = c.Double(nullable: false),
                        EmployeeComp = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BillingID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BillingModels");
        }
    }
}
