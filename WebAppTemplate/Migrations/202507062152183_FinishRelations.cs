namespace PetBoardingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class FinishRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PetModels", "OwnerID", "dbo.OwnerModels");
            DropIndex("dbo.PetModels", new[] { "OwnerID" });
            DropColumn("dbo.PetModels", "OwnerID");
            AddColumn("dbo.OwnerModels", "PetID", c => c.Guid(nullable: false));
            CreateIndex("dbo.OwnerModels", "PetID");
            AddForeignKey("dbo.OwnerModels", "PetID", "dbo.PetModels", "PetID", cascadeDelete: false);
        }

        public override void Down()
        {
            DropForeignKey("dbo.OwnerModels", "PetID", "dbo.PetModels");
            DropIndex("dbo.OwnerModels", new[] { "PetID" });
            DropColumn("dbo.OwnerModels", "PetID");
            AddColumn("dbo.PetModels", "OwnerID", c => c.Guid(nullable: false));
            CreateIndex("dbo.PetModels", "OwnerID");
            AddForeignKey("dbo.PetModels", "OwnerID", "dbo.OwnerModels", "OwnerID", cascadeDelete: true);
        }
    }
}
