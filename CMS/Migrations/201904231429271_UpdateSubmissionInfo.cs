namespace CMS.CMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSubmissionInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "ConferenceId", c => c.Int(nullable: false));
            AddColumn("dbo.Submissions", "Title", c => c.String());
            AddColumn("dbo.Submissions", "Representation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Submissions", "Representation");
            DropColumn("dbo.Submissions", "Title");
            DropColumn("dbo.Submissions", "ConferenceId");
        }
    }
}
