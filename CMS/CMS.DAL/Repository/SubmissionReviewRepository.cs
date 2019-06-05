using System.Linq;

using CMS.CMS.DAL.DatabaseContext;
using CMS.CMS.DAL.Entities;
using System.Data.Entity;
using System.Collections.Generic;

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

        public IEnumerable<SubmissionReview> GetAll()
        {
            return context.SubmissionReviews.Include(a => a.Reviewer)
               .Include(a => a.Submission)
               .ToList();
        }

        public SubmissionReview GetSubmissionReview(int submissionId, string reviewerId)
        {
            return context.SubmissionReviews.Include(a => a.Reviewer)
                .Include(a => a.Submission)
                .SingleOrDefault(s => s.SubmissionId == submissionId
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