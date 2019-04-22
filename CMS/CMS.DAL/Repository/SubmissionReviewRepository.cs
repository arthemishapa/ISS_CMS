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

        public void AddSubmissionReview(SubmissionReview submissionReview)
        {

        }

        public void UpdateSubmissionReview(SubmissionReview submissionReview)
        {

        }

        public SubmissionReview GetSubmissionReviewsForSubmission(int submissionId)
        {
            return null;
        }
    }
}