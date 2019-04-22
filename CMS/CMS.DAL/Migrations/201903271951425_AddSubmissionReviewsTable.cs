using System.Data.Entity.Migrations;

namespace CMS.CMS.DAL.Migrations
{
    public partial class AddSubmissionReviewsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubmissionReviews",
                c => new
                    {
                        SubmissionId = c.Int(nullable: false),
                        ReviewerId = c.String(nullable: false, maxLength: 128),
                        Review = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubmissionId, t.ReviewerId })
                .ForeignKey("dbo.AspNetUsers", t => t.ReviewerId, cascadeDelete: true)
                .ForeignKey("dbo.Submissions", t => t.SubmissionId, cascadeDelete: true)
                .Index(t => t.SubmissionId)
                .Index(t => t.ReviewerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubmissionReviews", "SubmissionId", "dbo.Submissions");
            DropForeignKey("dbo.SubmissionReviews", "ReviewerId", "dbo.AspNetUsers");
            DropIndex("dbo.SubmissionReviews", new[] { "ReviewerId" });
            DropIndex("dbo.SubmissionReviews", new[] { "SubmissionId" });
            DropTable("dbo.SubmissionReviews");
        }
    }
}
