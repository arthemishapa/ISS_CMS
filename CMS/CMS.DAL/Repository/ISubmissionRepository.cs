using CMS.CMS.DAL.Entities;

namespace CMS.CMS.DAL.Repository
{
    public interface ISubmissionRepository
    {
        void AddSubmission(Submission submission);
        void UpdateSubmission(Submission submission);
        void DeleteSubmission(Submission submission);
        Submission GetSubmissionById(int submissionId);
    }
}