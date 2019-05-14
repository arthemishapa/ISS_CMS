namespace CMS.CMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modify_SubmissionReview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubmissionReviews", "Recommendation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubmissionReviews", "Recommendation");
        }
    }
}
