using CMS.CMS.DAL.Entities;
using System.Collections.Generic;

namespace CMS.CMS.DAL.Repository
{
    public interface ISubmissionReviewRepository
    {
        void AddSubmissionReview(SubmissionReview submissionReview);
        void UpdateSubmissionReview(SubmissionReview submissionReview);
        SubmissionReview GetSubmissionReview(int submissionId, string reviewerId);
        IEnumerable<SubmissionReview> GetAll();
    }
}