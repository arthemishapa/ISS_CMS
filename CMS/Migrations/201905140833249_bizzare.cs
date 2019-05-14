namespace CMS.CMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bizzare : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropTable("dbo.UserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: true),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateIndex("dbo.UserRoles", "RoleId");
            CreateIndex("dbo.UserRoles", "UserId");
            AddForeignKey("dbo.UserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
    }
}
