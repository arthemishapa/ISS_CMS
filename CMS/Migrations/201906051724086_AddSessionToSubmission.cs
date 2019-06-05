namespace CMS.CMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSessionToSubmission : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "SessionId", c => c.Int());
            CreateIndex("dbo.Submissions", "SessionId");
            AddForeignKey("dbo.Submissions", "SessionId", "dbo.Sessions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Submissions", "SessionId", "dbo.Sessions");
            DropIndex("dbo.Submissions", new[] { "SessionId" });
            DropColumn("dbo.Submissions", "SessionId");
        }
    }
}
