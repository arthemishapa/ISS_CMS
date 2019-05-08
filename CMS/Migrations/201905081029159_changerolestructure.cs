namespace CMS.CMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changerolestructure : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserRoles");
            AddColumn("dbo.UserRoles", "ConferenceId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UserRoles", new[] { "UserId", "RoleId", "ConferenceId", "SectionId" });
            CreateIndex("dbo.UserRoles", "ConferenceId");
            AddForeignKey("dbo.UserRoles", "ConferenceId", "dbo.Conferences", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "ConferenceId", "dbo.Conferences");
            DropIndex("dbo.UserRoles", new[] { "ConferenceId" });
            DropPrimaryKey("dbo.UserRoles");
            DropColumn("dbo.UserRoles", "ConferenceId");
            AddPrimaryKey("dbo.UserRoles", new[] { "UserId", "RoleId", "SectionId" });
        }
    }
}
