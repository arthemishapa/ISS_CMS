using System.Linq;

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
            context.SubmissionReviews.Add(submissionReview);
            context.SaveChanges();
        }

        public SubmissionReview GetSubmissionReview(int submissionId, string reviewerId)
        {
            return context.SubmissionReviews.SingleOrDefault(s => s.SubmissionId == submissionId
                && s.ReviewerId == reviewerId);
        }

        public void UpdateSubmissionReview(SubmissionReview submissionReview)
        {
            var review = GetSubmissionReview(submissionReview.SubmissionId, submissionReview.ReviewerId);

            review.Review = submissionReview.Review;
            review.Recommendation = submissionReview.Recommendation;

            context.SaveChanges();
        }
    }
}