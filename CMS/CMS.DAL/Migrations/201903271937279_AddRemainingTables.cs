using System.Data.Entity.Migrations;

namespace CMS.CMS.DAL.Migrations
{
    public partial class AddRemainingTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        AbstractPaperDeadline = c.DateTime(nullable: false),
                        ProposalPaperDeadline = c.DateTime(nullable: false),
                        BiddingDeadline = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessions", t => t.SessionId, cascadeDelete: true)
                .Index(t => t.SessionId);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConferenceId = c.Int(nullable: false),
                        ChairId = c.String(maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ChairId)
                .ForeignKey("dbo.Conferences", t => t.ConferenceId, cascadeDelete: true)
                .Index(t => t.ConferenceId)
                .Index(t => t.ChairId);
            
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.String(maxLength: 128),
                        Data = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.Int(nullable: false),
                        SectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId, t.SectionId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId)
                .Index(t => t.SectionId);
            
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "PersonalWebpage", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserRoles", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Submissions", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sections", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.Sessions", "ConferenceId", "dbo.Conferences");
            DropForeignKey("dbo.Sessions", "ChairId", "dbo.AspNetUsers");
            DropIndex("dbo.UserRoles", new[] { "SectionId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.Submissions", new[] { "AuthorId" });
            DropIndex("dbo.Sessions", new[] { "ChairId" });
            DropIndex("dbo.Sessions", new[] { "ConferenceId" });
            DropIndex("dbo.Sections", new[] { "SessionId" });
            AlterColumn("dbo.AspNetUsers", "PersonalWebpage", c => c.String(maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 50));
            DropTable("dbo.UserRoles");
            DropTable("dbo.Submissions");
            DropTable("dbo.Sessions");
            DropTable("dbo.Sections");
            DropTable("dbo.Roles");
            DropTable("dbo.Conferences");
        }
    }
}
