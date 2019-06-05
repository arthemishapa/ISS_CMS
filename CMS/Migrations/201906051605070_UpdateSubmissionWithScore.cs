namespace CMS.CMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSubmissionWithScore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "Mark", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Submissions", "Mark");
        }
    }
}
