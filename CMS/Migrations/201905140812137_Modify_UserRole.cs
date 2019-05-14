namespace CMS.CMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modify_UserRole : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoles", "ConferenceId", "dbo.Conferences");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserRoles", new[] { "ConferenceId" });
            DropIndex("dbo.UserRoles", new[] { "SectionId" });
            DropTable("dbo.UserRoles");
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: true),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId})
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true);
            
            //DropTable("dbo.UserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.Int(nullable: false),
                    ConferenceId = c.Int(nullable: false),
                    SectionId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId, t.ConferenceId, t.SectionId });

            DropForeignKey("dbo.UserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropTable("dbo.UserRoles");
            CreateIndex("dbo.UserRoles", "SectionId");
            CreateIndex("dbo.UserRoles", "ConferenceId");
            AddForeignKey("dbo.UserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "SectionId", "dbo.Sections", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "ConferenceId", "dbo.Conferences", "Id", cascadeDelete: true);
        }
    }
}
