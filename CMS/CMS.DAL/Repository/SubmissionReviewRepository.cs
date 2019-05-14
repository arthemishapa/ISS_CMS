using CMS.CMS.DAL.DatabaseContext;
using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public class SubmissionReviewRepository : ISubmissionReviewRepository
    {
        private readonly CMSDbContext context;

        public SubmissionReviewRepository(CMSDbContext context)
        {
            this.context = context;
        }

        public void AddSubmission(SubmissionReview submissionReview)
        {
            context.SubmissionReviews.Add(submissionReview);
            context.SaveChanges();
        }
    }
}