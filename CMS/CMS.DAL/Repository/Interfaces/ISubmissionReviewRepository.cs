using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface ISubmissionReviewRepository
    {
        void AddSubmission(SubmissionReview submissionReview);
    }
}